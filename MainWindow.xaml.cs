using System.Net.Http;
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
        private CancellationTokenSource _cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            btnCalculate.IsEnabled = false;
            cpuResult.Text = "Вычисление...";
            cpuProgress.Value = 0;

            try
            {
                long result = await Task.Run(() => CalculateSumWithProgress(new Progress<int>(progress => {
                    Dispatcher.BeginInvoke(new Action(() => cpuProgress.Value = progress));
                })));

                cpuResult.Text = $"Результат: {result:N0}";
            }
            catch (Exception ex)
            {
                cpuResult.Text = $"Ошибка: {ex.Message}";
            }
            finally
            {
                btnCalculate.IsEnabled = true;
            }
        }

        private long CalculateSumWithProgress(IProgress<int> progress)
        {
            long sum = 0;
            int totalSteps = 100;

            for (int i = 1; i <= totalSteps; i++)
            {
                for (int j = 0; j < 1000000; j++)
                {
                    sum += j;
                }

                progress.Report(i);

                Thread.Sleep(20);
            }

            return sum;
        }

        private async void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            btnLoadData.IsEnabled = false;
            httpResult.Text = "Загрузка...";

            try
            {
                Thread.Sleep(1000); // http stuff
                string data = "{\"date\": \"" + (DateTime.Now.ToString()) + "\"}";
                httpResult.Text = $"Данные: {data.Substring(0, Math.Min(100, data.Length))}";
            }
            catch (Exception ex)
            {
                httpResult.Text = $"Ошибка загрузки: {ex.Message}";
            }
            finally
            {
                btnLoadData.IsEnabled = true;
            }
        }

        private void btnBlocking_Click(object sender, RoutedEventArgs e)
        {
            btnBlocking.IsEnabled = false;
            blockingStatus.Text = "Блокирующая операция... (UI заблокирован)";

            Thread.Sleep(5000);

            blockingStatus.Text = "Операция завершена";
            btnBlocking.IsEnabled = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cpuProgress.Value = 0;
            cpuResult.Text = "Результат: Ожидание вычисления";
            httpResult.Text = "Данные: Ожидание загрузки";
            blockingStatus.Text = "Статус: Готов";
        }

        protected override void OnClosed(EventArgs e)
        {
            _cancellationTokenSource?.Dispose();
            base.OnClosed(e);
        }
    }
}