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
    /// Logika interakcji dla klasy Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
            
        }

        private void bRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tbPassword.Password == tbConfirmPassword.Password)
                {
                    Users users = new Users();
                    try
                    {
                        users = XMLHelper.getUsersData();
                    }
                    catch (Exception exc) { }
                    if (users == null)
                        users = new Users();
                    User user = new User
                    {
                        Login = tbLogin.Text,
                        Password = tbPassword.Password
                    };
                    users.Add(user);
                    XMLHelper.saveData(users, "users.xml");
                    MessageBox.Show("Registration complete");
                } else
                {
                    MessageBox.Show("Passwords don't match");
                }
                
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
