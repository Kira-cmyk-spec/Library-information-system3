using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система.PageAppWorker
{
    /// <summary>
    /// Логика взаимодействия для PageAddWorker.xaml
    /// </summary>
    public partial class PageAddWorker : Page
    {
        public static List<Client> clients { get; set; }
        public ObservableCollection<Client> clients1 { get; set; }
        public PageAddWorker()
        {
            InitializeComponent();
        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Client client = new Client()
                {
                    Name = NameTextBox.Text,
                    Surname = NameTextBox.Text,
                    Patronymic = NameTextBox.Text,
                    login = NameTextBox.Text,
                    password = NameTextBox.Text,
                    id_role = 2,
                    IsDelete = true

                };
              


                App.Connetction.Client.Add(client);
          



                App.Connetction.SaveChanges();
                MessageBox.Show("Добавление произошло  успешно ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
