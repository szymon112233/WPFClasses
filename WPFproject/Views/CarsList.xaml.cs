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
    /// Interaction logic for CarsList.xaml
    /// </summary>
    public partial class CarsList : UserControl
    {
        List<Car> items = new List<Car>();

        public CarsList()
        {
            InitializeComponent();

            this.IsVisibleChanged += CarsList_IsVisibleChanged;
        }

        private void CarsList_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                Cars cars = XMLHelper.getCarsData();
                items = cars.GetCars().Cast<Car>().ToList();
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
                    Cars products = new Cars();
                    foreach (Car car in items)
                    {
                        products.Add(car);
                    }
                    XMLHelper.saveData(products, "cars.xml");
                }
            }
        }
    }
}
