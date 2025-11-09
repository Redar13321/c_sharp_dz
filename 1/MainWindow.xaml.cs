using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SemaphoreSlim _fileSemaphore = new SemaphoreSlim(3, 3);
        private readonly ReaderWriterLockSlim _fileLock = new ReaderWriterLockSlim();
        private readonly string _filePath = "shared_file.txt";
        private int _waitingTasks = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFile();
            UpdateSemaphoreInfo();
            Log("Приложение инициализировано. Создан семафор с 3 разрешениями.");
        }

        private void InitializeFile()
        {
            try
            {
                File.WriteAllText(_filePath, "Начальное содержимое файла\n");
                Log("Файл инициализирован");
            }
            catch (Exception ex)
            {
                Log($"Ошибка инициализации файла: {ex.Message}");
            }
        }

        private async void btnStartTasks_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Запуск 5 задач записи ===");

            for (int i = 1; i <= 5; i++)
            {
                await StartFileWriteTask(i);
            }
        }

        private async Task StartFileWriteTask(int taskId)
        {
            Interlocked.Increment(ref _waitingTasks);
            UpdateSemaphoreInfo();

            Log($"[Задача {taskId}] Ожидание разрешения...");

            try
            {
                await _fileSemaphore.WaitAsync();
                Interlocked.Decrement(ref _waitingTasks);
                UpdateSemaphoreInfo();

                Log($"[Задача {taskId}] Разрешение получено. Начало записи...");

                await Task.Delay(2000);

                _fileLock.EnterWriteLock();
                try
                {
                    string content = $"Запись от задачи {taskId} в {DateTime.Now:HH:mm:ss}\n";
                    await File.AppendAllTextAsync(_filePath, content);
                    Log($"[Задача {taskId}] Запись завершена: {content.Trim()}");
                }
                finally
                {
                    _fileLock.ExitWriteLock();
                }
            }
            catch (Exception ex)
            {
                Log($"[Задача {taskId}] Ошибка: {ex.Message}");
            }
            finally
            {
                _fileSemaphore.Release();
                UpdateSemaphoreInfo();
                Log($"[Задача {taskId}] Разрешение освобождено");
            }
        }

        private async void btnClearFile_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Очистка файла с WriterLock ===");

            try
            {
                _fileLock.EnterWriteLock();
                try
                {
                    Log("WriterLock захвачен - начинаю очистку файла...");
                    await File.WriteAllTextAsync(_filePath, $"Файл очищен в {DateTime.Now:HH:mm:ss}\n");
                    Log("Файл успешно очищен");
                }
                finally
                {
                    _fileLock.ExitWriteLock();
                    Log("WriterLock освобожден");
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка при очистке файла: {ex.Message}");
            }
        }

        private void btnShowFile_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Чтение содержимого файла ===");

            try
            {
                _fileLock.EnterReadLock();
                try
                {
                    if (File.Exists(_filePath))
                    {
                        string content = File.ReadAllText(_filePath);
                        Log($"Содержимое файла:\n{content}");
                    }
                    else
                    {
                        Log("Файл не существует");
                    }
                }
                finally
                {
                    _fileLock.ExitReadLock();
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        private void Log(string message)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                logListBox.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
                logListBox.ScrollIntoView(logListBox.Items[logListBox.Items.Count - 1]);
            }));
        }

        private void UpdateSemaphoreInfo()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                semaphoreStatus.Text = $"{_fileSemaphore.CurrentCount}/3";
                waitingTasks.Text = _waitingTasks.ToString();
            }));
        }
    }
}