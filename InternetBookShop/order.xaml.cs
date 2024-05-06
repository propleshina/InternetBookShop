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
    /// Логика взаимодействия для order.xaml
    /// </summary>
    public partial class order : Page
    {
        public order()
        {
            InitializeComponent();

            var context = InternetBookShop_KyrcahEntities.GetContext();
            var query = from Orders in context.Orders
                        join Client in context.Client on Orders.client_id equals Client.client_id
                        join addresses in context.addresses on Orders.addressID equals addresses.address_id
                        join payment in context.payment on Orders.paymentID equals payment.payment_id
                        join order_status in context.order_status on Orders.orderstatusID equals order_status.status_id
                        select new
                        {
                            Id = Orders.order_id,
                            Клиент = Client.name,
                            Город = addresses.city,
                            СтатусОплаты = payment.name,
                            СтатусЗаказа= order_status.name
  
                        };

            OrderData.ItemsSource = query.ToList();

            string fullpath = "C:\\Users\\217047\\Source\\Repos\\propleshina\\InternetBookShop\\InternetBookShop\\IsAdmin.txt";
            string filecontent = File.ReadAllText(fullpath);
            if (filecontent.Trim().ToLower() == "false")
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
                OrderData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().Orders.ToList();

                RedactButton.Content = "Выйти из режима редактирования";
                OrderData.IsReadOnly = false;
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;

                SaveButton.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
            }
            else
            {
                var context = InternetBookShop_KyrcahEntities.GetContext();
                var query = from Orders in context.Orders
                            join Client in context.Client on Orders.client_id equals Client.client_id
                            join addresses in context.addresses on Orders.addressID equals addresses.address_id
                            join payment in context.payment on Orders.paymentID equals payment.payment_id
                            join order_status in context.order_status on Orders.orderstatusID equals order_status.status_id
                            select new
                            {
                                Id = Orders.order_id,
                                Клиент = Client.name,
                                Город = addresses.city,
                                СтатусОплаты = payment.name,
                                СтатусЗаказа = order_status.name

                            };

                OrderData.ItemsSource = query.ToList();

                RedactButton.Content = "Редактировать";
                DeleteButton.Visibility = Visibility.Hidden;
                DeleteButton.IsEnabled = false;
                SaveButton.Visibility = Visibility.Hidden;
                SaveButton.IsEnabled = false;
                OrderData.IsReadOnly = true;
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = OrderData.SelectedItems.Cast<Orders>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().Orders.RemoveRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var row = OrderData.SelectedItems.Cast<Orders>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().Orders.AddRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
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
            string fullpath = "C:\\Users\\217047\\Source\\Repos\\propleshina\\InternetBookShop\\InternetBookShop\\IsAdmin.txt";

            File.WriteAllText(fullpath, string.Empty);
            File.WriteAllText(fullpath, "false");
            NavigationService.Navigate(new Page1());
        }
    }
}
