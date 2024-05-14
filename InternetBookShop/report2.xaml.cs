using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для report2.xaml
    /// </summary>
    public partial class report2 : Page
    {
        public report2()
        {
            InitializeComponent();

            string itog = "SELECT SUM(shopping_cart.summ) AS 'Рублей'\r\nFROM Orders \r\nINNER JOIN shopping_cart ON Orders.cartID=shopping_cart.cart_id \r\n INNER JOIN order_status ON Orders.orderstatusID=order_status.status_id WHERE order_status.name='Заказ получен'";

            string query =
    "SELECT Orders.order_id, Client.name AS Имя, Client.surname AS Фамилия, Client.patronymic AS Отчество, shopping_cart.summ AS Сумма, order_status.name AS СтатусЗаказа\r\nFROM Orders \r\nINNER JOIN Client ON Orders.client_id = Client.client_id\r\n INNER JOIN order_status ON Orders.orderstatusID=order_status.status_id INNER JOIN shopping_cart ON Orders.cartID=shopping_cart.cart_id WHERE order_status.name='Заказ получен'";
            using (SqlConnection con = new SqlConnection("Data Source=BD-KIP\\SQLEXPRESS;Initial Catalog=InternetBookShop_Kyrcah;User ID=sa;Password=1qaz!QAZ;"))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                report2Data.Items.Clear();
                report2Data.DataContext = dt;
                report2Data.ItemsSource = dt.DefaultView;

                SqlDataAdapter adapter2 = new SqlDataAdapter(itog, con);
                DataTable dataTable2 = new DataTable();
                adapter2.Fill(dataTable2);

                itogovayasum2.DataContext = dataTable2;
                itogovayasum2.ItemsSource = dataTable2.DefaultView;
            }
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

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Return());
        }

        private void sign_out_Click(object sender, RoutedEventArgs e)
        {
            UserContext.IsAdmin = false;
            NavigationService.Navigate(new Page1());
        }

        private void Client_but(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new order());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BD());
        }
    }
}
