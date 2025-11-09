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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int sharedCounter = 0;
        private readonly object lockObject = new object();
        private List<string> sharedList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateDebugInfo("Приложение инициализировано");
        }

        // 1.
        private void btnStartRace_Click(object sender, RoutedEventArgs e)
        {
            sharedCounter = 0;
            raceResult.Text = "Результат: Выполняется...";
            raceStatus.Text = "Статус: Запущена гонка данных";

            UpdateDebugInfo("=== Запуск гонки данных ===");

            Thread thread1 = new Thread(() => IncrementUnsafe(1000, "Поток 1"));
            Thread thread2 = new Thread(() => IncrementUnsafe(1000, "Поток 2"));

            thread1.Start();
            thread2.Start();

            Thread waitThread = new Thread(() =>
            {
                thread1.Join();
                thread2.Join();

                Dispatcher.Invoke(() =>
                {
                    raceResult.Text = $"Результат: {sharedCounter}";
                    raceStatus.Text = "Статус: Завершено";

                    string status = sharedCounter == 2000 ? "✓ КОРРЕКТНО" : "✗ ОШИБКА - гонка данных!";
                    UpdateDebugInfo($"Гонка данных завершена. Результат: {sharedCounter} {status}");
                    UpdateDebugInfo($"Ожидалось: 2000, Получено: {sharedCounter}");
                });
            });
            waitThread.Start();
        }

        private void IncrementUnsafe(int iterations, string threadName)
        {
            for (int i = 0; i < iterations; i++)
            {
                int temp = sharedCounter;
                Thread.Sleep(1);
                sharedCounter = temp + 1;

                Dispatcher.Invoke(() =>
                {
                    UpdateDebugInfo($"{threadName}: sharedCounter = {sharedCounter}");
                });
            }
        }

        // 2.
        private void btnSafeAdd_Click(object sender, RoutedEventArgs e)
        {
            sharedList.Clear();
            safeListBox.Items.Clear();
            safeStatus.Text = "Элементов: 0";

            UpdateDebugInfo("=== Запуск безопасного добавления ===");

            Thread thread1 = new Thread(() => AddItemsSafely("Item-A", 50, "Поток 1"));
            Thread thread2 = new Thread(() => AddItemsSafely("Item-B", 50, "Поток 2"));

            thread1.Start();
            thread2.Start();

            Thread waitThread = new Thread(() =>
            {
                thread1.Join();
                thread2.Join();

                Dispatcher.Invoke(() =>
                {
                    safeStatus.Text = $"Элементов: {sharedList.Count}";
                    UpdateDebugInfo($"Безопасное добавление завершено. Элементов: {sharedList.Count}");

                    if (sharedList.Count == 100)
                    {
                        UpdateDebugInfo("✓ Все элементы добавлены корректно");
                    }
                    else
                    {
                        UpdateDebugInfo("✗ Ошибка: не все элементы добавлены");
                    }
                });
            });
            waitThread.Start();
        }

        private void AddItemsSafely(string prefix, int count, string threadName)
        {
            for (int i = 0; i < count; i++)
            {
                string item = $"{prefix}-{i}";

                lock (lockObject)
                {
                    sharedList.Add(item);

                    Dispatcher.Invoke(() =>
                    {
                        safeListBox.Items.Add(item);
                        UpdateDebugInfo($"{threadName} добавил: {item} (под защитой lock)");
                    });
                }

                Thread.Sleep(10);
            }
        }

        private void btnMonitorTest_Click(object sender, RoutedEventArgs e)
        {
            monitorStatus.Text = "Статус: Выполняется...";
            UpdateDebugInfo("=== Тест Monitor.TryEnter ===");

            Thread thread1 = new Thread(() =>
            {
                lock (lockObject)
                {
                    Dispatcher.Invoke(() =>
                    {
                        UpdateDebugInfo("Поток 1: Блокировка захвачена на 2 секунды");
                        monitorResult.Text = "Поток 1 удерживает блокировку";
                    });

                    Thread.Sleep(2000);

                    Dispatcher.Invoke(() =>
                    {
                        UpdateDebugInfo("Поток 1: Блокировка освобождена");
                    });
                }
            });

            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(100);

                bool lockAcquired = false;
                try
                {
                    Dispatcher.Invoke(() =>
                    {
                        UpdateDebugInfo("Поток 2: Попытка захвата блокировки с таймаутом 1 секунда");
                    });

                    lockAcquired = Monitor.TryEnter(lockObject, 1000);

                    if (lockAcquired)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            UpdateDebugInfo("✓ Поток 2: Блокировка успешно захвачена");
                            monitorResult.Text = "Поток 2 получил блокировку";
                            monitorStatus.Text = "Статус: Успех";
                        });

                        Thread.Sleep(500);
                    }
                    else
                    {
                        Dispatcher.Invoke(() =>
                        {
                            UpdateDebugInfo("✗ Поток 2: Таймаут - не удалось захватить блокировку");
                            monitorResult.Text = "Таймаут - блокировка не получена";
                            monitorStatus.Text = "Статус: Таймаут";
                        });
                    }
                }
                finally
                {
                    if (lockAcquired)
                    {
                        Monitor.Exit(lockObject);
                        Dispatcher.Invoke(() =>
                        {
                            UpdateDebugInfo("Поток 2: Блокировка освобождена");
                        });
                    }
                }
            });

            thread1.Start();
            thread2.Start();
        }


        private void UpdateDebugInfo(string message)
        {
            Dispatcher.BeginInvoke(new Action(() => debugInfoList.Items.Add($"[{DateTime.Now:HH:mm:ss.fff}] {message}")));
        }
    }
}