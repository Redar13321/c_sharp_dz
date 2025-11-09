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
        private readonly SemaphoreSlim _dbSemaphore = new SemaphoreSlim(4, 4);
        private readonly ReaderWriterLockSlim _configLock = new ReaderWriterLockSlim();
        private readonly Mutex _appMutex;
        private readonly string _configData = "Конфигурация БД по умолчанию";
        private int _activeOperations = 0;
        private bool _mutexCreated;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                _appMutex = new Mutex(true, "DatabaseAccessDemoApp", out _mutexCreated);
                if (!_mutexCreated)
                {
                    Log("Предупреждение: Другой экземпляр приложения уже запущен!");
                }
                else
                {
                    Log("Mutex создан - это первый экземпляр приложения");
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка создания Mutex: {ex.Message}");
            }

            UpdateStatus();
            Log("Приложение инициализировано. Создан семафор с 4 подключениями.");
        }

        private async void btnStartConnections_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Запуск 8 подключений к БД ===");

            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 8; i++)
            {
                tasks.Add(StartDatabaseOperation(i));
            }

            await Task.WhenAll(tasks);
            Log("Все подключения завершены");
        }

        private async Task StartDatabaseOperation(int operationId)
        {
            Interlocked.Increment(ref _activeOperations);
            UpdateStatus();

            Log($"[Операция {operationId}] Ожидание подключения...");

            try
            {
                await _dbSemaphore.WaitAsync();
                Log($"[Операция {operationId}] Подключение установлено");

                await Task.Delay(3000);

                Log($"[Операция {operationId}] Операция завершена успешно");
            }
            catch (Exception ex)
            {
                Log($"[Операция {operationId}] Ошибка: {ex.Message}");
            }
            finally
            {
                _dbSemaphore.Release();
                Interlocked.Decrement(ref _activeOperations);
                UpdateStatus();
                Log($"[Операция {operationId}] Подключение закрыто");
            }
        }

        private void btnReadConfig_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Чтение конфигурации ===");

            _configLock.EnterReadLock();
            try
            {
                Log("ReaderLock захвачен - чтение конфигурации...");

                Task.Delay(500).Wait();

                Dispatcher.BeginInvoke(new Action(() => currentConfig.Text = _configData));

                Log($"Конфигурация прочитана: {_configData}");
            }
            finally
            {
                _configLock.ExitReadLock();
                Log("ReaderLock освобожден");
            }
        }

        private void btnUpdateConfig_Click(object sender, RoutedEventArgs e)
        {
            Log("=== Обновление конфигурации ===");

            _configLock.EnterWriteLock();
            try
            {
                Log("WriterLock захвачен - обновление конфигурации...");

                Task.Delay(1000).Wait();

                string newConfig = $"Обновленная конфигурация от {DateTime.Now:HH:mm:ss}";

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    currentConfig.Text = newConfig;
                }));

                Log($"Конфигурация обновлена: {newConfig}");
            }
            finally
            {
                _configLock.ExitWriteLock();
                Log("WriterLock освобожден");
            }
        }

        private void btnCheckInstance_Click(object sender, RoutedEventArgs e)
        {
            if (_mutexCreated)
            {
                Log("✓ Это единственный экземпляр приложения (Mutex создан этим процессом)");
            }
            else
            {
                Log("✗ Обнаружены другие экземпляры приложения (Mutex уже существовал)");
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

        private void UpdateStatus()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                connectionStatus.Text = $"{_dbSemaphore.CurrentCount}/4";
                activeOperations.Text = _activeOperations.ToString();
            }));
        }

        protected override void OnClosed(EventArgs e)
        {
            _appMutex?.Close();
            base.OnClosed(e);
        }
    }
}