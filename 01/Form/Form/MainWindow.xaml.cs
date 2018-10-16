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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Form
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            tbimie.Clear();
            tbnazwisko.Clear();
            dpbday.SelectedDate = null;
            cbplec.SelectedItem = null;
        }

        private void Click_Save(object sender, RoutedEventArgs e)
        {
            Models.Person person = new Models.Person();
            person.Name = tbimie.Text;
            person.Surname = tbnazwisko.Text;
            if (cbplec.SelectedItem != null)
                person.Sex = (Models.Sex)cbplec.SelectedIndex;
            if (dpbday.SelectedDate != null)
                person.Bday = dpbday.SelectedDate ?? DateTime.Now;
        }
    }
}
