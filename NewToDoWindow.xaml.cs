using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для NewDealWindow.xaml
    /// </summary>
    public partial class NewToDoWindow : Window
    {
        public NewToDoWindow()
        {
            InitializeComponent();
        }

        public void ButtonSave_Clicked(object sender, RoutedEventArgs e)
        {
            var inputText = nameInput.Text;
            if (inputText == null)
                return;
            inputText = inputText.Trim();
            if (inputText.Length == 0)
                return;
            ((MainWindow)Owner).AddNewToDo(new ToDo(inputText, descriptionInput.Text?.Trim(), false, dateInput.SelectedDate));
            this.Close();
        }
    }
}
