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
    /// Interaction logic for CarForm.xaml
    /// </summary>
    public partial class CarForm : UserControl
    {
        public CarForm()
        {
            InitializeComponent();
        }

        private void CleanForm()
        {
            tbName.Clear();
            tbBrand.Clear();
            tbType.Clear();
            tbPlates.Clear();
            tbNotes.Clear();
            dpDate.SelectedDate = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text != string.Empty && tbBrand.Text != string.Empty && tbType.Text != string.Empty && tbPlates.Text != string.Empty && dpDate.SelectedDate != null)
                {
                    Cars cars = new Cars();
                    try
                    {
                        cars = XMLHelper.getCarsData();
                    }
                    catch (Exception exc) { }
                    if (cars == null)
                        cars = new Cars();
                    Car car = new Car
                    {
                        Name = tbName.Text,
                        Brand = tbBrand.Text,
                        Type = tbType.Text,
                        Plates = tbPlates.Text,
                        Notes = tbNotes.Text,
                        DateBought = dpDate.SelectedDate ?? DateTime.Now
                    };
                    cars.Add(car);
                    XMLHelper.saveData(cars, "cars.xml");
                    MessageBox.Show("Car added!");
                    CleanForm();
                }
                else
                {
                    MessageBox.Show("PLease fill in all the fields!");
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
