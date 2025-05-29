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

namespace WpfApp9
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			//object e;
			//e = listToDo;
			//e = groupBoxToDo;
			//e = titleToDo;
			//e = dateToDo;
			//e = descriptionToDo;
			//e = buttonAdd;

			InitializeComponent();

			listToDo.ItemsSource = new List<ToDo>()
			{
				new("job one", "guaguaguaguaguaguagua"),
				new("job two", "guaguaguaguaguaguagua"),
				new("job three", "guaguaguaguaguaguagua"),
			};
		}

        private void toogleVisiblityToDo_Clicked(object sender, RoutedEventArgs e)
        {
            if (buttonAdd == null || groupBoxToDo == null) return;
			CheckBox checkBox = (CheckBox)sender;
            bool v = checkBox.IsChecked == true;
            groupBoxToDo.Visibility = v ? Visibility.Visible : Visibility.Hidden;
            buttonAdd.Visibility = groupBoxToDo.Visibility;
        }
    }
}