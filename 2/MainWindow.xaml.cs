using System.Net.NetworkInformation;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queue<string> itemQueue = new Queue<string>();
        private readonly object queueLock = new object();
        private Thread producerThread;
        private Thread consumerThread;
        private CancellationTokenSource producerCts;
        private CancellationTokenSource consumerCts;
        private int producedCount = 0;
        private int consumedCount = 0;
        private bool isProducerWaiting = false;
        private bool isConsumerWaiting = false;

        public MainWindow()
        {
            InitializeComponent();
            UpdateSyncDebugInfo("Система Producer-Consumer готова");
        }

        private void btnStartProducer_Click(object sender, RoutedEventArgs e)
        {
            if (producerThread?.IsAlive == true)
            {
                producerCts?.Cancel();
                producerThread.Join(500);
            }

            producerCts = new CancellationTokenSource();
            producerThread = new Thread(() => ProducerWork(producerCts.Token));
            producerThread.Name = "Producer";
            producerThread.IsBackground = true;
            producerThread.Start();

            UpdateSyncDebugInfo("Производитель запущен");
            pcStatus.Text = "Статус: Производитель работает";
        }

        private void btnStartConsumer_Click(object sender, RoutedEventArgs e)
        {
            if (consumerThread?.IsAlive == true)
            {
                consumerCts?.Cancel();
                consumerThread.Join(500);
            }

            consumerCts = new CancellationTokenSource();
            consumerThread = new Thread(() => ConsumerWork(consumerCts.Token));
            consumerThread.Name = "Consumer";
            consumerThread.IsBackground = true;
            consumerThread.Start();

            UpdateSyncDebugInfo("Потребитель запущен");
            pcStatus.Text = "Статус: Оба работают";
        }

        private void btnStopAll_Click(object sender, RoutedEventArgs e)
        {
            producerCts?.Cancel();
            consumerCts?.Cancel();

            lock (queueLock)
            {
                Monitor.PulseAll(queueLock);
            }

            pcStatus.Text = "Статус: Остановлено";
            UpdateSyncDebugInfo("Все потоки остановлены");
        }

        private void ProducerWork(CancellationToken token)
        {
            int itemId = 0;

            while (!token.IsCancellationRequested)
            {
                string item = $"Элемент-{itemId++}";

                lock (queueLock)
                {
                    itemQueue.Enqueue(item);
                    producedCount++;

                    Dispatcher.Invoke(() =>
                    {
                        queueListBox.Items.Add(item);
                        producedCountText.Text = $"Произведено: {producedCount}";
                        queueSizeText.Text = $"В очереди: {itemQueue.Count}";
                        logListBox.Items.Add($"[PRODUCER] Создал: {item}");
                    });

                    UpdateSyncDebugInfo($"Производитель: добавил {item}, очередь: {itemQueue.Count}");

                    if (isConsumerWaiting)
                    {
                        UpdateSyncDebugInfo("Производитель: уведомляю потребителя (Pulse)");
                        Monitor.Pulse(queueLock);
                        isConsumerWaiting = false;
                    }
                }

                Thread.Sleep(500);

                if (itemQueue.Count >= 5)
                {
                    lock (queueLock)
                    {
                        if (itemQueue.Count >= 5 && !token.IsCancellationRequested)
                        {
                            UpdateSyncDebugInfo("Производитель: очередь полная, жду (Wait)");
                            isProducerWaiting = true;
                            Monitor.Wait(queueLock);
                            isProducerWaiting = false;
                            UpdateSyncDebugInfo("Производитель: разбужен, продолжаю работу");
                        }
                    }
                }
            }

            Dispatcher.Invoke(() =>
            {
                logListBox.Items.Add("[PRODUCER] Остановлен");
            });
        }

        private void ConsumerWork(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                string? item = null;

                lock (queueLock)
                {
                    if (itemQueue.Count == 0)
                    {
                        if (!token.IsCancellationRequested)
                        {
                            UpdateSyncDebugInfo("Потребитель: очередь пустая, жду (Wait)");
                            isConsumerWaiting = true;
                            Monitor.Wait(queueLock);
                            isConsumerWaiting = false;
                            UpdateSyncDebugInfo("Потребитель: разбужен, проверяю очередь");
                        }

                        if (token.IsCancellationRequested) break;
                    }

                    if (itemQueue.Count > 0)
                    {
                        item = itemQueue.Dequeue();
                        consumedCount++;

                        Dispatcher.Invoke(() =>
                        {
                            if (queueListBox.Items.Count > 0)
                                queueListBox.Items.RemoveAt(0);
                            consumedCountText.Text = $"Обработано: {consumedCount}";
                            queueSizeText.Text = $"В очереди: {itemQueue.Count}";
                            logListBox.Items.Add($"[CONSUMER] Обработал: {item}");
                        });

                        UpdateSyncDebugInfo($"Потребитель: обработал {item}, очередь: {itemQueue.Count}");

                        if (isProducerWaiting)
                        {
                            UpdateSyncDebugInfo("Потребитель: уведомляю производителя (Pulse)");
                            Monitor.Pulse(queueLock);
                            isProducerWaiting = false;
                        }
                    }
                }

                if (item != null)
                {
                    Thread.Sleep(1000);
                }
            }

            Dispatcher.Invoke(() =>
            {
                logListBox.Items.Add("[CONSUMER] Остановлен");
            });
        }

        private void UpdateSyncDebugInfo(string message)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                syncDebugInfoList.Items.Add($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
            }));
        }

        protected override void OnClosed(EventArgs e)
        {
            producerCts?.Cancel();
            consumerCts?.Cancel();

            lock (queueLock)
            {
                Monitor.PulseAll(queueLock);
            }

            base.OnClosed(e);
        }
    }
}