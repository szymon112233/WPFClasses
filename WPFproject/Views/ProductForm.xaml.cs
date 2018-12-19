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
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : UserControl
    {
        public ProductForm()
        {
            InitializeComponent();
            cbStatus.Items.Add(Status.SALE);
            cbStatus.Items.Add(Status.DISCOUNT);
            cbStatus.Items.Add(Status.WAREHOUSE);
            cbStatus.Items.Add(Status.REMOVED);
        }

        private void CleanForm()
        {
            tbName.Clear();
            tbDesc.Clear();
            tbPrice.Clear();
            tbQuantity.Clear();
            cbStatus.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text == string.Empty || tbDesc.Text == string.Empty || tbPrice.Text == string.Empty || tbQuantity.Text == string.Empty || cbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all the fields!");
                }
                else if (!float.TryParse(tbPrice.Text, out float tempFloat))
                {
                    MessageBox.Show("Price must be a number!");
                }

                else if (!int.TryParse(tbQuantity.Text, out int tempInt))
                {
                    MessageBox.Show("Quanitity must be an Integer!");
                }
                else
                {
                    Products products = new Products();
                    try
                    {
                        products = XMLHelper.getProductsData();
                    }
                    catch (Exception exc) { }
                    if (products == null)
                        products = new Products();
                    Product car = new Product
                    {
                        Name = tbName.Text,
                        Price = tempFloat,
                        Desc = tbDesc.Text,
                        Quantity = tempInt,
                        Status = (Status)cbStatus.SelectedItem,
                    };
                    products.Add(car);
                    XMLHelper.saveData(products, "products.xml");
                    MessageBox.Show("Product added!");
                    CleanForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CleanForm();
        }
    }
}
