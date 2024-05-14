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
    /// Логика взаимодействия для Return.xaml
    /// </summary>
    public partial class Return : Page
    {
        public Return()
        {
                        //            ReturnData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().returns.ToList();

            InitializeComponent();
            var context = InternetBookShop_KyrcahEntities.GetContext();
            var query = from returns in context.returns
                        join Orders in context.Orders on returns.orderID equals Orders.order_id
                        select new
                        {
                            Id = returns.return_id,
                            Название = Orders.order_id

                        };

            ReturnData.ItemsSource = query.ToList();

            RedactButton.Content = "Редактировать";
            DeleteButton.Visibility = Visibility.Hidden;
            DeleteButton.IsEnabled = false;
            SaveButton.Visibility = Visibility.Hidden;
            SaveButton.IsEnabled = false;
            ReturnData.IsReadOnly = true;


            if (UserContext.IsAdmin == false)
            {
                RedactButton.Visibility = Visibility.Hidden;
            }
            else
            {
                RedactButton.Visibility = Visibility.Visible;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BD());
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(RedactButton.Content) == "Редактировать")
            {
                ReturnData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().returns.ToList();

                RedactButton.Content = "Выйти из режима редактирования";
                ReturnData.IsReadOnly = false;
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;

                SaveButton.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
            }
            else
            {
                var context = InternetBookShop_KyrcahEntities.GetContext();
                var query = from returns in context.returns
                            join Orders in context.Orders on returns.orderID equals Orders.order_id
                            select new
                            {
                                Id = returns.return_id,
                                Название = Orders.order_id

                            };

                ReturnData.ItemsSource = query.ToList();

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
            UserContext.IsAdmin = false;
            NavigationService.Navigate(new Page1());
        }
    }
}
