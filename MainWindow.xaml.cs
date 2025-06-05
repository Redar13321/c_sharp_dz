using System.Collections;
using System.Collections.Generic;
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

        DateTime? _defaultDateToDo;
        String? _defaultDescriptionToDo;
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

            _defaultDescriptionToDo = descriptionToDo.Text;
            _defaultDateToDo = dateToDo.SelectedDate;
            updateListToDo(new List<ToDo>());
            /*
            updateListToDo(new List<ToDo>()
            {
                new("job one", "guaguaguaguaguaguagua", _defaultDateToDo),
                new("job two", "guaguaguaguaguaguagua", _defaultDateToDo),
                new("job three", "guaguaguaguaguaguagua", _defaultDateToDo),
            });
            */
        }

        private void toogleVisiblityToDo_Clicked(object sender, RoutedEventArgs e)
        {
            if (buttonAdd == null || groupBoxToDo == null) return;
			CheckBox checkBox = (CheckBox)sender;
            bool v = checkBox.IsChecked == true;
            groupBoxToDo.Visibility = v ? Visibility.Visible : Visibility.Hidden;
            buttonAdd.Visibility = groupBoxToDo.Visibility;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (titleToDo.Text == null || titleToDo.Text.TrimEnd().Length == 0)
                return;

			var newToDo = new ToDo(titleToDo.Text, descriptionToDo.Text, dateToDo.SelectedDate);
            //list.Remove(listToDo.SelectedValue as ToDo);
            titleToDo.Text = null;
            descriptionToDo.Text = _defaultDescriptionToDo;
            dateToDo.SelectedDate = _defaultDateToDo;

            var list = listToDo.ItemsSource as List<ToDo>;
            list.Add(newToDo);
            updateListToDo(list);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
			if (listToDo.SelectedIndex == -1)
				return;
			var list = listToDo.ItemsSource as List<ToDo>;
            //list.Remove(listToDo.SelectedValue as ToDo);
            list.RemoveAt(listToDo.SelectedIndex);
			updateListToDo(list);
        }
		void updateListToDo(IEnumerable? newItems = null)
        {
            newItems ??= listToDo.ItemsSource;
            var list = newItems as List<ToDo>;
            list.Sort((a, b) => DateTime.Compare(a.Date, b.Date));
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = list;
        }
    }
}