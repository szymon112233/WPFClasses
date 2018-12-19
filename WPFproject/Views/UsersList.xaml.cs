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

namespace DatabaseWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UsersList : UserControl
    {

        List<User> items = new List<User>();

        public UsersList()
        {
            InitializeComponent();

            this.IsVisibleChanged += UsersList_IsVisibleChanged;
        }

        private void UsersList_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                Users users = XMLHelper.getUsersData();
                items = users.GetUsers().Cast<User>().ToList();
                lvList.ItemsSource = items;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delte this row?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (lvList.SelectedIndex > -1 && lvList.SelectedIndex < items.Count)
                {
                    items.RemoveAt(lvList.SelectedIndex);
                    lvList.ItemsSource = items;
                    lvList.Items.Refresh();
                    Users products = new Users();
                    foreach (User user in items)
                    {
                        products.Add(user);
                    }
                    XMLHelper.saveData(products, "users.xml");
                }
            }
        }
    }
}
