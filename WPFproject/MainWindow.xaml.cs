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
using DatabaseWPF.Models;

namespace DatabaseWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HideComponents()
        {
            vLogin.Visibility = Visibility.Hidden;
            vRegistration.Visibility = Visibility.Hidden;
            vUserList.Visibility = Visibility.Hidden;
            vCarForm.Visibility = Visibility.Hidden;
            vCarsList.Visibility = Visibility.Hidden;
            vProductForm.Visibility = Visibility.Hidden;
            vProductsList.Visibility = Visibility.Hidden;
        }

        private void bNewUser_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vRegistration.Visibility = Visibility.Visible;
        }

        private void bUserList_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vUserList.Visibility = Visibility.Visible;
        }

        private void bNewProdyct_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vProductForm.Visibility = Visibility.Visible;
        }

        private void bProductList_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vProductsList.Visibility = Visibility.Visible;
        }

        private void bNewCar_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vCarForm.Visibility = Visibility.Visible;
        }

        private void bCarList_Click(object sender, RoutedEventArgs e)
        {
            HideComponents();
            vCarsList.Visibility = Visibility.Visible;
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
