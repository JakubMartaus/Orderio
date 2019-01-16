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
using System.Net.Http;
using Newtonsoft.Json;
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

        public async void Get()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://student.sps-prosek.cz/~martaja15/Files/API/api.php");

            string json = await response.Content.ReadAsStringAsync();
            //dynamic c = JsonConvert.DeserializeObject(json);
            List<Objects.User> c = JsonConvert.DeserializeObject<List<Objects.User>>(json);

            //string text = c[0].Gender;

            // test.Content = text;
            int ctr = c.Count();
            for (int i = 0; i < ctr; i++)
            {
                /*ApiObject api = new ApiObject();
                api.ID = c[i].ID;
                api.Name = c[i].Name;
                api.Surname = c[i].Surname;
                api.PIN = c[i].PIN;
                api.Birthdate = c[i].Birthdate;
                api.Gender = c[i].Gender;

                listView.Items.Add(api);*/
                if(username.Text == c[i].Username && password.Password == c[i].Password)
                {
                    this.NavigationService.Navigate(new UserPage());
                }
                else
                {
                    if (i == ctr)
                    {
                        MessageBox.Show("Špatné přihlašovací údaje");
                    }

                }

            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Get();
           /* if (username.Text == jmeno && password.Password == heslo)
            {
                this.NavigationService.Navigate(new UserPage());
            }
            else
            {
                MessageBox.Show("Wrong name or password!");
            }*/
        }
        private void Registrace_Clicked(object sender, MouseButtonEventArgs e)
        {

            this.NavigationService.Navigate(new RegistrationPage());
        }
    }
}
