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

namespace Orderio
{
    /// <summary>
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

        }
        string jmeno = "martaja15";
        string heslo = "orderio123";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == jmeno && password.Text == heslo)
            {
                this.NavigationService.Navigate(new UserPage());
            }
            else
            {
                MessageBox.Show("Wrong name or password!");
            }
        }
    }
}
