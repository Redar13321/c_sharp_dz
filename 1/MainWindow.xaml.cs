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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread progressThread;
        private Thread priorityThread;
        private CancellationTokenSource progressCts;
        private CancellationTokenSource priorityCts;

        public MainWindow()
        {
            InitializeComponent();
            progressCts = new CancellationTokenSource();
            priorityCts = new CancellationTokenSource();

            UpdateDebugInfo("Приложение инициализировано");
        }

        // 1.
        private void btnStartProgress_Click(object sender, RoutedEventArgs e)
        {
            if (progressThread?.IsAlive == true)
            {
                progressCts.Cancel();
                progressThread.Join(500);
            }

            progressCts = new CancellationTokenSource();
            progressThread = new Thread(() => UpdateProgressBar(progressCts.Token));
            progressThread.Name = "ProgressThread";
            progressThread.IsBackground = true;
            progressThread.Start();

            UpdateDebugInfo("Запущен поток с прогресс-баром");
        }

        private void UpdateProgressBar(CancellationToken token)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Dispatcher.Invoke(() => progressText.Text = "Отменено");
                    return;
                }

                Dispatcher.Invoke(() =>
                {
                    progressBar.Value = i;
                    progressText.Text = $"Выполнено: {i}%";
                });

                Thread.Sleep(50);
            }

            Dispatcher.Invoke(() => progressText.Text = "Завершено!");
        }

        // 2
        private void btnStartPriority_Click(object sender, RoutedEventArgs e)
        {
            if (priorityThread?.IsAlive == true)
            {
                priorityCts.Cancel();
                priorityThread.Join(500);
            }

            priorityCts = new CancellationTokenSource();
            priorityThread = new Thread(() => HighPriorityWork(priorityCts.Token));
            priorityThread.Name = "PriorityThread";
            priorityThread.Priority = ThreadPriority.Normal;
            priorityThread.IsBackground = true;
            priorityThread.Start();

            UpdateDebugInfo("Запущен поток с изменяемым приоритетом");
        }

        private void HighPriorityWork(CancellationToken token)
        {
            int counter = 0;

            Dispatcher.Invoke(() => priorityText.Text = "Приоритет: Normal");

            for (int i = 0; i < 50; i++)
            {
                if (token.IsCancellationRequested) return;
                counter++;

                Dispatcher.Invoke(() => priorityCounter.Text = $"Счетчик: {counter}");
                Thread.Sleep(100);
            }

            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Dispatcher.Invoke(() =>
            {
                priorityText.Text = "Приоритет: Highest (изменен во время выполнения)";
                UpdateDebugInfo("Приоритет потока изменен на Highest");
            });

            for (int i = 0; i < 50; i++)
            {
                if (token.IsCancellationRequested) return;
                counter++;

                Dispatcher.Invoke(() => priorityCounter.Text = $"Счетчик: {counter}");
                Thread.Sleep(100);
            }

            Dispatcher.Invoke(() => priorityText.Text = "Приоритет: Завершено");
        }

        // 3
        private void btnCauseError_Click(object sender, RoutedEventArgs e)
        {
            Thread errorThread = new Thread(() => UpdateUIWithoutDispatcher());
            errorThread.Name = "ErrorThread";
            errorThread.IsBackground = true;
            errorThread.Start();

            UpdateDebugInfo("Запущен поток для демонстрации ошибки");
        }

        private void UpdateUIWithoutDispatcher()
        {
            try
            {
                errorText.Text = "Это вызовет ошибку!";
            }
            catch (InvalidOperationException ex)
            {
                Dispatcher.Invoke(() =>
                {
                    errorText.Text = $"Ошибка: {ex.Message}";
                    UpdateDebugInfo($"Поймана ошибка: {ex.GetType().Name}");
                });
            }
        }

        private void UpdateDebugInfo(string message)
        {
            debugInfoList.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        protected override void OnClosed(EventArgs e)
        {
            progressCts.Cancel();
            priorityCts.Cancel();

            base.OnClosed(e);
        }
    }
}