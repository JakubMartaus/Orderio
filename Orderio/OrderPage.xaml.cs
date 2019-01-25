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
    /// Interakční logika pro OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            ObjednavkaList.Items.Clear();
            Get();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserPage());
        }


        public async void Get()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://orderio.czech-trip-transport.com/sklad.php");

            string json = await response.Content.ReadAsStringAsync();
            //dynamic c = JsonConvert.DeserializeObject(json);
            List<Objects.Product> c = JsonConvert.DeserializeObject<List<Objects.Product>>(json);

            //string text = c[0].Gender;

            // test.Content = text;
            int ctr = c.Count();
            for (int i = 0; i < ctr; i++)
            {
                Objects.Sklad sklad = new Objects.Sklad();
                sklad.Name = c[i].Name;
                sklad.Price = c[i].Price;


                ObjednavkaList.Items.Add(sklad);


            }


        }
    }
}
