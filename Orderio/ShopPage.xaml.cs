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
    /// Interakční logika pro ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {

        public int userIDcko = 1;
        

        Objects.testik t = new Objects.testik();
        //public string userID = "1";
        public ShopPage()
        {
            InitializeComponent();
            Get();
        
        }
        public string User;
        public ShopPage(string userID) : this()
        {
            int x = Convert.ToInt32(userID);
            //   t.User_id = idcko;
            if (userIDcko < x) {
                userIDcko++;
            }

        }


        
        public async void Get()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://orderio.czech-trip-transport.com/produkt.php");

            string json = await response.Content.ReadAsStringAsync();
            //dynamic c = JsonConvert.DeserializeObject(json);
            List<Objects.Product> c = JsonConvert.DeserializeObject<List<Objects.Product>>(json);

            //string text = c[0].Gender;

            // test.Content = text;
            int ctr = c.Count();
            for (int i = 0; i < ctr; i++)
            {
                Objects.Product product = new Objects.Product();
                product.Name = c[i].Name;
                product.Price = c[i].Price;
         

                ProduktList.Items.Add(product);
               

            }


        }

      
        Objects.Product test;


        public async void Send()
        {
            // Vytvoření klienta
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://orderio.czech-trip-transport.com/produkt.php");
            // Data, která se přidají k POST dotazu -> klíč je typu string a data jsou typu string
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Name", test.Name));
            keyValues.Add(new KeyValuePair<string, string>("Price", test.Price));
            keyValues.Add(new KeyValuePair<string, string>("userID", userIDcko.ToString()));
           
            // Přidání dat do dotazu
            request.Content = new FormUrlEncodedContent(keyValues);
            // Zaslání POST dotazu
            var response = await client.SendAsync(request);
            // Získání odpovědi
            string responseContent = await response.Content.ReadAsStringAsync();
        }
        private void ProduktList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            test = (Objects.Product)ProduktList.SelectedItem;

            /*product.Name = test.Name;
            product.Price = test.Price;*/

            SkladList.Items.Add(test);
            // Sklad
            Send();



        }
        public async void Send2()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://orderio.czech-trip-transport.com/produkt.php");
            // Data, která se přidají k POST dotazu -> klíč je typu string a data jsou typu string
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Name", test.Name));
            keyValues.Add(new KeyValuePair<string, string>("Price", test.Price));
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
            this.NavigationService.Navigate(new UserPage());
        }

        private void Koupit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
