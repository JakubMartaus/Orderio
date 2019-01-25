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
    /// Interakční logika pro RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        string Username;
        string Firstname;
        string Lastname;
        string Password;
        string Confirm;
 
        public async void Send()
        {
            // Vytvoření klienta
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://orderio.czech-trip-transport.com/api.php");
            // Data, která se přidají k POST dotazu -> klíč je typu string a data jsou typu string
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Username", Username));
            keyValues.Add(new KeyValuePair<string, string>("Firstname", Firstname));
            keyValues.Add(new KeyValuePair<string, string>("Lastname", Lastname));
            keyValues.Add(new KeyValuePair<string, string>("Password", Password));
            keyValues.Add(new KeyValuePair<string, string>("Overeni", "post"));
            // Přidání dat do dotazu
            request.Content = new FormUrlEncodedContent(keyValues);
            // Zaslání POST dotazu
            var response = await client.SendAsync(request);
            // Získání odpovědi
            string responseContent = await response.Content.ReadAsStringAsync();
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Username = username.Text;
            Firstname = firstname.Text;
            Lastname = lastname.Text;
            Password = password.Password;
            Confirm = confirmpassword.Password;

            if (Password == Confirm)
            {
                Send();
                this.NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Hesla se neshodují.");
            }
        }
    }
}
