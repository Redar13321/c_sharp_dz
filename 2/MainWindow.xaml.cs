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
        private Thread? lowestThread;
        private Thread? normalThread;
        private Thread? highestThread;
        private CancellationTokenSource? threadsCts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStartThreads_Click(object sender, RoutedEventArgs e)
        {
            ResetThreads();
            threadsCts = new CancellationTokenSource();

            StartThread(ThreadPriority.Lowest, "LowestThread", txtLowest, threadsCts.Token);
            StartThread(ThreadPriority.Normal, "NormalThread", txtNormal, threadsCts.Token);
            StartThread(ThreadPriority.Highest, "HighestThread", txtHighest, threadsCts.Token);

            Thread waitThread = new Thread(() => WaitForThreadsCompletion());
            waitThread.Name = "WaitThread";
            waitThread.IsBackground = true;
            waitThread.Start();

            completionStatus.Text = "Статус: Потоки запущены...";
        }

        private void StartThread(ThreadPriority priority, string name, System.Windows.Controls.TextBlock textBlock, CancellationToken token)
        {
            Thread thread = new Thread(() => CountWithPriority(priority, name, textBlock, token));
            thread.Name = name;
            thread.Priority = priority;
            thread.IsBackground = true;
            thread.Start();

            switch (priority)
            {
                case ThreadPriority.Lowest: lowestThread = thread; break;
                case ThreadPriority.Normal: normalThread = thread; break;
                case ThreadPriority.Highest: highestThread = thread; break;
            }
        }

        private void CountWithPriority(ThreadPriority priority, string name, System.Windows.Controls.TextBlock textBlock, CancellationToken token)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (token.IsCancellationRequested) return;

                Dispatcher.Invoke(() => textBlock.Text = i.ToString());

                Thread.Sleep(100);
            }
        }

        private void WaitForThreadsCompletion()
        {
            lowestThread?.Join();
            normalThread?.Join();
            highestThread?.Join();

            Dispatcher.Invoke(() => completionStatus.Text = "Статус: Все потоки завершены!");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetThreads();
        }

        private void ResetThreads()
        {
            threadsCts?.Cancel();

            txtLowest.Text = "0";
            txtNormal.Text = "0";
            txtHighest.Text = "0";
            completionStatus.Text = "Статус: Сброшено";
        }

        protected override void OnClosed(EventArgs e)
        {
            threadsCts?.Cancel();

            base.OnClosed(e);
        }
    }
}