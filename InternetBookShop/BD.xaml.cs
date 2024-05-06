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
using System.IO;

namespace InternetBookShop
{
    /// <summary>
    /// Логика взаимодействия для BD.xaml
    /// </summary>
    public partial class BD : Page
    {
        public BD()
        {
            InitializeComponent();
        }

        private void Client_but(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Workers());
        }

        private void Publisher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new publishers());
        }
        private void Book_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new book());
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new order());
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Return());
        }

        private void sign_out_Click(object sender, RoutedEventArgs e)
        {
            string fullpath = "C:\\Users\\217047\\Source\\Repos\\propleshina\\InternetBookShop\\InternetBookShop\\IsAdmin.txt";

            File.WriteAllText(fullpath, string.Empty);
            File.WriteAllText(fullpath, "false");
            NavigationService.Navigate(new Page1());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new report1());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new report2());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new report3());
        }
    }
}
