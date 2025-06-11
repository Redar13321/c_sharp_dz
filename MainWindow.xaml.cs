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
		public MainWindow()
		{
			InitializeComponent();

            ListBoxToDo.ItemsSource = new List<ToDo>();
            updateBarToDo();
        }

		public void ButtonDelete_Clicked(object sender, RoutedEventArgs e)
		{
            if (ListBoxToDo.SelectedIndex == -1)
                return;
            List<ToDo> list = (List<ToDo>)ListBoxToDo.ItemsSource;
            list.RemoveAt(ListBoxToDo.SelectedIndex);
            ListBoxToDo.ItemsSource = null;
            ListBoxToDo.ItemsSource = list;
            updateBarToDo();
            //ListBoxToDo.Items.RemoveAt(ListBoxToDo.SelectedIndex);
        }
		public void ButtonNewToDo_Clicked(object sender, RoutedEventArgs e)
		{
			Window win = new NewToDoWindow();
			win.Owner = this;
			win.Show();
		}

        public void AddNewToDo(ToDo toDo)
        {
            List<ToDo> list = (List<ToDo>)ListBoxToDo.ItemsSource;
            list.Add(toDo);
            ListBoxToDo.ItemsSource = null;
            ListBoxToDo.ItemsSource = list;
            updateBarToDo();
        }

        public void onSetToDoIsDone(object sender, RoutedEventArgs e)
        {
            ToDo curToDo = (ListBoxToDo.SelectedValue as ToDo);
            if (curToDo != null)
            {
                curToDo.Done = (sender as CheckBox)?.IsChecked ?? curToDo.Done;
                updateBarToDo();
            }
        }

        void updateBarToDo()
		{
			if (ListBoxToDo.Items.Count > 0)
			{
                textBarToDO.Visibility = progBarToDO.Visibility = Visibility.Visible;
				progBarToDO.Maximum = ListBoxToDo.Items.Count;
				progBarToDO.Value = (ListBoxToDo.ItemsSource as List<ToDo>).Count(i=>i.Done);
				textBarToDO.Text = $"{progBarToDO.Value}/{progBarToDO.Maximum}";
            }
			else
            {
                textBarToDO.Visibility = progBarToDO.Visibility = Visibility.Collapsed;
            }
		}
	}
}