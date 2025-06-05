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
		}

		public void ButtonDelete_Clicked(object sender, RoutedEventArgs e)
		{
            if (ListBoxToDo.SelectedIndex == -1)
                return;
            List<ToDo> list = (List<ToDo>)ListBoxToDo.ItemsSource;
            list.RemoveAt(ListBoxToDo.SelectedIndex);
            ListBoxToDo.ItemsSource = null;
            ListBoxToDo.ItemsSource = list;
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
			//ListBoxToDo.Items.RemoveAt(ListBoxToDo.SelectedIndex);
        }
	}
}