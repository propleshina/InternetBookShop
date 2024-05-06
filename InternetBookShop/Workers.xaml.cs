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
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Workers : Page
    {
        public Workers()
        {
            InitializeComponent();
            //WorkerData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().workers.ToList();
            var context = InternetBookShop_KyrcahEntities.GetContext();
            var query = from workers in context.workers
                        join jobs in context.jobs on workers.jobID equals jobs.job_id
                        select new
                        {
                            Id = workers.worker_id,
                            Имя = workers.name,
                            Фамилия = workers.surname,
                            Отчество = workers.patronymic,
                            Пол = workers.gender,
                            Должность = jobs.name

                        };

            WorkerData.ItemsSource = query.ToList();


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
                WorkerData.ItemsSource = InternetBookShop_KyrcahEntities.GetContext().workers.ToList();
                RedactButton.Content = "Выйти из режима редактирования";
                WorkerData.IsReadOnly = false;
                DeleteButton.Visibility = Visibility.Visible;
                DeleteButton.IsEnabled = true;

                SaveButton.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
            }
            else
            {
                var context = InternetBookShop_KyrcahEntities.GetContext();
                var query = from workers in context.workers
                            join jobs in context.jobs on workers.jobID equals jobs.job_id
                            select new
                            {
                                Id = workers.worker_id,
                                Имя = workers.name,
                                Фамилия = workers.surname,
                                Отчество = workers.patronymic,
                                Пол = workers.gender,
                                Должность = jobs.name

                            };

                WorkerData.ItemsSource = query.ToList();

                RedactButton.Content = "Редактировать";
                DeleteButton.Visibility = Visibility.Hidden;
                DeleteButton.IsEnabled = false;
                SaveButton.Visibility = Visibility.Hidden;
                SaveButton.IsEnabled = false;
                WorkerData.IsReadOnly = true;
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = WorkerData.SelectedItems.Cast<workers>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().workers.RemoveRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var row = WorkerData.SelectedItems.Cast<workers>().ToList();
            InternetBookShop_KyrcahEntities.GetContext().workers.AddRange(row);
            InternetBookShop_KyrcahEntities.GetContext().SaveChanges();
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
