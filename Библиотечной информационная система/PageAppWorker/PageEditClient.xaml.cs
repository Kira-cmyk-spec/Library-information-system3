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
using Библиотечной_информационная_система.ClassApp;

namespace Библиотечной_информационная_система.PageAppWorker
{
    /// <summary>
    /// Логика взаимодействия для PageEditClient.xaml
    /// </summary>
    public partial class PageEditClient : Page
    {
        public PageEditClient()
        {
            InitializeComponent();
            this.DataContext = App.Connetction.Client.Where(z => z.id == Class_User.CorrClient.id).FirstOrDefault();
        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");

        }
    }
}
