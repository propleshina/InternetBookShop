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
    }
}
