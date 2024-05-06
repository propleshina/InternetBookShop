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
    /// Логика взаимодействия для book.xaml
    /// </summary>
    public partial class book : Page
    {
        public book()
        {
            InitializeComponent();

            var context = InternetBookShop_KyrcahEntities.GetContext();
            var query = from Product in context.Product
                        join Author in context.Author on Product.authorID equals Author.author_id
                        join Genre in context.Genre on Product.genreID equals Genre.genre_id
                        join Category in context.Category on Product.categoryID equals Category.category_id
                        join Publisher in context.Publisher on Product.publisherID equals Publisher.publisher_id
                        select new
                        {
                            Id = Product.product_id,
                            Название = Product.name,
                            Автор = Author.name,
                            Жанр = Genre.name,
                            Описание = Product.description,
                            Вес = Product.weight,
                            Цена = Product.cost,
                            Издательство = Publisher.name,
                            Категория = Category.name
                        };

            BookData.ItemsSource = query.ToList();



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
                BookData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().Product.ToList();

                RedactButton.Content = "Выйти из режима редактирования";
                BookData.IsReadOnly = false;
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;

                SaveButton.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
            }
            else
            {
                var context = InternetBookShop_KyrcahEntities.GetContext();
                var query = from Product in context.Product
                            join Author in context.Author on Product.authorID equals Author.author_id
                            join Genre in context.Genre on Product.genreID equals Genre.genre_id
                            join Category in context.Category on Product.categoryID equals Category.category_id
                            join Publisher in context.Publisher on Product.publisherID equals Publisher.publisher_id
                            select new
                            {
                                Id = Product.product_id,
                                Название = Product.name,
                                Автор = Author.name,
                                Жанр = Genre.name,
                                Описание = Product.description,
                                Вес = Product.weight,
                                Цена = Product.cost,
                                Издательство = Publisher.name,
                                Категория = Category.name
                            };

                BookData.ItemsSource = query.ToList();


                RedactButton.Content = "Редактировать";
                DeleteButton.Visibility = Visibility.Hidden;
                DeleteButton.IsEnabled = false;
                SaveButton.Visibility = Visibility.Hidden;
                SaveButton.IsEnabled = false;
                BookData.IsReadOnly = true;
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = BookData.SelectedItems.Cast<Product>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().Product.RemoveRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var row = BookData.SelectedItems.Cast<Product>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().Product.AddRange(row);
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
   
    }
}
