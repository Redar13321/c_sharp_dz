using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process notepadProcess;

        private Thread dataLoadingThread;
        private bool isLoadingCancelled = false;
        private CancellationTokenSource cancellationTokenSource;

        private int sharedCounter = 0;
        private readonly object counterLock = new object();
        private int completedThreads = 0;

        private SemaphoreSlim semaphore;
        private List<string> sharedCollection;
        private int processedItems = 0;

        public MainWindow()
        {
            InitializeComponent();
            semaphore = new SemaphoreSlim(3, 3);
        }

        // Запуск внешних процессов
        private void BtnStartNotepad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                notepadProcess = new Process();
                notepadProcess.StartInfo.FileName = "notepad.exe";
                notepadProcess.EnableRaisingEvents = true;
                notepadProcess.Exited += NotepadProcess_Exited;
                notepadProcess.Start();

                tbNotepadStatus.Text = "Статус: Notepad запущен";
                btnStartNotepad.IsEnabled = false;
                btnKillNotepad.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска Notepad: {ex.Message}");
            }
        }

        private void NotepadProcess_Exited(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                tbNotepadStatus.Text = "Статус: Notepad завершен";
                btnStartNotepad.IsEnabled = true;
                btnKillNotepad.IsEnabled = false;
                notepadProcess = null;
            });
        }

        private void BtnKillNotepad_Click(object sender, RoutedEventArgs e)
        {
            if (notepadProcess != null && !notepadProcess.HasExited)
            {
                notepadProcess.Kill();
            }
        }

        // Работа с потоками и Dispatcher
        private void BtnLoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            List<String> files = openFileDialog.FileNames.ToList();
            if (files.Count() == 0)
            {
                return;
            }

            btnLoadData.IsEnabled = false;
            btnStopLoading.IsEnabled = true;
            isLoadingCancelled = false;
            cancellationTokenSource = new CancellationTokenSource();

            dataLoadingThread = new Thread(() => LoadDataSimulation(cancellationTokenSource.Token, files));
            dataLoadingThread.IsBackground = true;
            dataLoadingThread.Start();
        }

        private void LoadDataSimulation(CancellationToken cancellationToken, List<String> files)
        {
            try
            {
                int length = files.Count;
                Dispatcher.Invoke(() => progressBar.Maximum = length);
                for (int i = 0; i < length; i++)
                {
                    if (cancellationToken.IsCancellationRequested || isLoadingCancelled)
                    {
                        return;
                    }

                    Dispatcher.Invoke(() => addItem(lbFiles, $"Чтение файла \"{files[i]}\"") );

                    int totalLines = 0;
                    using (StreamReader reader = new StreamReader(files[i]))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Thread.Sleep(30);
                            totalLines++;
                            Dispatcher.Invoke(() => addItem(lbFiles, $" [{(totalLines).ToString().PadLeft(3, '0')}]: {line}"));
                        }
                    }

                    Dispatcher.Invoke(() =>
                    {
                        progressBar.Value = i + 1;
                        tbProgressStatus.Text = $"Загрузка... {Math.Floor((i + 1.0) / length * 100.0)}%";
                        //addItem(lbFiles, $"Всего линий:{totalLines}");
                    });
                }

                Dispatcher.Invoke(() =>
                {
                    tbProgressStatus.Text = "Загрузка завершена!";
                    tbLoadedData.Text = "Данные успешно загружены из файла!";
                    btnLoadData.IsEnabled = true;
                    btnStopLoading.IsEnabled = false;
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    tbProgressStatus.Text = $"Ошибка: {ex.Message}";
                });
            }
        }

        private void BtnStopLoading_Click(object sender, RoutedEventArgs e)
        {
            isLoadingCancelled = true;
            cancellationTokenSource?.Cancel();

            btnLoadData.IsEnabled = true;
            btnStopLoading.IsEnabled = false;
            tbProgressStatus.Text = "Загрузка остановлена";
        }

        // Синхронизация через lock
        private void BtnStartCounter_Click(object sender, RoutedEventArgs e)
        {
            sharedCounter = 0;
            completedThreads = 0;
            tbCounterValue.Text = "Счетчик: 0";
            tbCounterStatus.Text = "Статус: Потоки запущены";
            btnStartCounter.IsEnabled = false;

            var thread1 = new Thread(IncrementCounter);
            var thread2 = new Thread(IncrementCounter);

            thread1.IsBackground = true;
            thread2.IsBackground = true;

            thread1.Start();
            thread2.Start();
        }

        private void IncrementCounter()
        {
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                lock (counterLock)
                {
                    sharedCounter++;
                }

                // Небольшая задержка для имитации работы
                Thread.Sleep(rnd.Next(1, 5));
            }

            Interlocked.Increment(ref completedThreads);

            Dispatcher.Invoke(() =>
            {
                if (completedThreads == 2)
                {
                    tbCounterValue.Text = $"Счетчик: {sharedCounter}";
                    tbCounterStatus.Text = "Статус: Оба потока завершены";
                    btnStartCounter.IsEnabled = true;
                }
            });
        }

        // Семафор для ограничения параллелизма
        private void BtnStartSemaphore_Click(object sender, RoutedEventArgs e)
        {
            lbSemaphoreLog.Items.Clear();
            processedItems = 0;
            sharedCollection = new List<string>();

            for (int i = 1; i <= 10; i++)
            {
                sharedCollection.Add($"Элемент {i}");
            }

            tbSemaphoreStatus.Text = "Статус: Запуск 10 потоков с ограничением в 3 одновременных";
            btnStartSemaphore.IsEnabled = false;

            for (int i = 0; i < 10; i++)
            {
                int threadNumber = i + 1;
                Task.Run(() => ProcessWithSemaphore(threadNumber));
            }
        }

        private async void ProcessWithSemaphore(int threadNumber)
        {
            await semaphore.WaitAsync();

            try
            {
                string itemToProcess = null;

                lock (sharedCollection)
                {
                    if (sharedCollection.Count > 0)
                    {
                        itemToProcess = sharedCollection[0];
                        sharedCollection.RemoveAt(0);
                    }
                }

                if (itemToProcess != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        addItem(lbSemaphoreLog, $"Поток {threadNumber} начал обработку: {itemToProcess}");
                    });

                    // Имитация работы
                    await Task.Delay(2000);

                    int currentProcessed = Interlocked.Increment(ref processedItems);

                    Dispatcher.Invoke(() =>
                    {
                        lbSemaphoreLog.Items.Add($"Поток {threadNumber} завершил: {itemToProcess}");
                        lbSemaphoreLog.ScrollIntoView(lbSemaphoreLog.Items[lbSemaphoreLog.Items.Count - 1]);

                        if (currentProcessed == 10)
                        {
                            tbSemaphoreStatus.Text = "Статус: Все элементы обработаны!";
                            btnStartSemaphore.IsEnabled = true;
                        }
                    });
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        private void addItem(ListBox listBox, string message)
        {
            listBox.Items.Add(message);
            listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
        }
    }
}