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
    /// Логика взаимодействия для report3.xaml
    /// </summary>
    public partial class report3 : Page
    {
        public report3()
        {
            InitializeComponent();

            ChooseCategory.Items.Add("Книги");
            ChooseCategory.Items.Add("Канцелярия");
            ChooseCategory.Items.Add("Сувениры");
           
            report3Data.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().Product.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BD());
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        { 
        var row = report3Data.SelectedItems.Cast<Orders>().ToList();
        InternetBookShop_KyrcahEntities.GetContext().Orders.RemoveRange(row);
        InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var row = report3Data.SelectedItems.Cast<Orders>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().Orders.AddRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Workers());
        }
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());
        }

        private void Publisher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new publishers());
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new book());
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Return());
        }

        private void sign_out_Click(object sender, RoutedEventArgs e)
        {
            UserContext.IsAdmin = false;
            NavigationService.Navigate(new Page1());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orders());
        }

        private void ChooseCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedcategoryid = ChooseCategory.SelectedIndex + 1;

            var filteredproducts = InternetBookShop_KyrcahEntities.GetContext().Product.Where(p => p.categoryID == selectedcategoryid).ToList();
            report3Data.ItemsSource = filteredproducts;
        }
    }
}
