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

namespace InternetBookShop
{
    /// <summary>
    /// Логика взаимодействия для Return.xaml
    /// </summary>
    public partial class Return : Page
    {
        public Return()
        {
            InitializeComponent();
            ReturnData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().returns.ToList();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BD());
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(RedactButton.Content) == "Редактировать")
            {
                RedactButton.Content = "Выйти из режима редактирования";
                ReturnData.IsReadOnly = false;
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;

                SaveButton.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
            }
            else
            {
                RedactButton.Content = "Редактировать";
                DeleteButton.Visibility = Visibility.Hidden;
                DeleteButton.IsEnabled = false;
                SaveButton.Visibility = Visibility.Hidden;
                SaveButton.IsEnabled = false;
                ReturnData.IsReadOnly = true;
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = ReturnData.SelectedItems.Cast<returns>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().returns.RemoveRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var row = ReturnData.SelectedItems.Cast<returns>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().returns.AddRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Workers());
        }

        private void Publisher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new publishers());
        }
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new book());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new order());
        }

        private void sign_out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
