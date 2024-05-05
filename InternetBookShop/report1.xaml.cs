using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для report1.xaml
    /// </summary>
    public partial class report1 : Page
    {
        public report1()
        {
            InitializeComponent();
            string itog = "SELECT SUM(shopping_cart.summ) AS 'Рублей'\r\nFROM Orders \r\nINNER JOIN shopping_cart ON Orders.cartID=shopping_cart.cart_id\r\nINNER JOIN order_status ON Orders.orderstatusID=order_status.status_id";

            string query =
                "SELECT Orders.order_id, Client.name AS cName, Client.surname AS sName, Client.patronymic AS pName, shopping_cart.summ AS summ\r\nFROM Orders \r\nINNER JOIN Client ON Orders.client_id = Client.client_id\r\nINNER JOIN shopping_cart ON Orders.cartID=shopping_cart.cart_id";
           using (SqlConnection con = new SqlConnection("Data Source=SHKAFF_2-0;Initial Catalog=InternetBookShop_Kyrcah;User ID=ima;Password=Kkn67913070;"))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                report1Data.DataContext = dataTable;
                report1Data.ItemsSource = dataTable.DefaultView;

                SqlDataAdapter adapter2 = new SqlDataAdapter(itog, con);
                DataTable dataTable2 = new DataTable();
                adapter2.Fill(dataTable2);

                itogovayasum.DataContext = dataTable2;
                itogovayasum.ItemsSource = dataTable2.DefaultView;
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
             NavigationService.Navigate(new order());
        }

    }
}
