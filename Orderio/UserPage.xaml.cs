﻿using System;
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
    /// Interakční logika pro UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
       
        public UserPage()
        {
            InitializeComponent();
            
           
       
        }
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void Nakup_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShopPage());
        }

        private void Objednavky_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrderPage());
        }
    }
}
