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
using System.IO;



namespace InternetBookShop
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>


    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            string fullpath = "C:\\Users\\217047\\Source\\Repos\\propleshina\\InternetBookShop\\InternetBookShop\\IsAdmin.txt";

            File.WriteAllText(fullpath, string.Empty);
            File.WriteAllText(fullpath, "false");
        }
        public System.Windows.ResizeMode NoResize { get; set; }
        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginBox.Text) && string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            else if (string.IsNullOrEmpty(loginBox.Text))
            {
                MessageBox.Show("Вы не ввели логин!");
            }
            else if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Вы не ввели пароль!");
            }
            else
            {
                using (var db = new InternetBookShop_KyrcahEntities())
                {

                    var user = db.workers.AsNoTracking().FirstOrDefault(u => u.login == loginBox.Text && u.password == passwordBox.Password);
                    if (user == null)
                    {
                        MessageBox.Show($"Учётная запись не найдена");
                    }
                    else
                    {
                        if (loginBox.Text == "admin")
                        {
                            string fullpath = "C:\\Users\\217047\\Source\\Repos\\propleshina\\InternetBookShop\\InternetBookShop\\IsAdmin.txt";

                            File.WriteAllText(fullpath, string.Empty);
                            File.WriteAllText(fullpath, "true");
                        }
                        MessageBox.Show($"Здравствуйте, {user.name} {user.patronymic}!");
                        loginBox.Clear();
                        passwordBox.Clear();
                        NavigationService.Navigate(new BD());
                    }
                }
            }
        }
    }
}
