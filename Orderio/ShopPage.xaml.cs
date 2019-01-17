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
        public ShopPage()
        {
            InitializeComponent();
            Get();
        }
        public async void Get()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://student.sps-prosek.cz/~martaja15/Files/API/produkt.php");

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
    }
}
