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
    /// Interaction logic for ProductsList.xaml
    /// </summary>
    public partial class ProductsList : UserControl
    {
        List<Product> items;

        public ProductsList()
        {
            InitializeComponent();

            this.IsVisibleChanged += ProductsList_IsVisibleChanged;
        }

        private void ProductsList_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                Products products = XMLHelper.getProductsData();
                items = products.GetProducts().Cast<Product>().ToList();
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
                    Products products = new Products();
                    foreach (Product prod in items)
                    {
                        products.Add(prod);
                    }
                    XMLHelper.saveData(products, "products.xml");
                }
            }
        }
    }
}
