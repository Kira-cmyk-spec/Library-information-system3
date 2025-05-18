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
    /// Логика взаимодействия для PageAddClient.xaml
    /// </summary>
    public partial class PageAddClient : Page
    {
        public static List<Client> clients { get; set; }
        public ObservableCollection<Client> clients1 { get; set; }
        public static List<Group_student> group_Students { get; set; }
 
        public PageAddClient()
        {
            InitializeComponent();
        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            try
            {
                var _cat = GroupComboBox.SelectedItem as Group_student;
                Client client = new Client()
                {
                    Name = NameTextBox.Text,
                    Surname = NameTextBox.Text,
                    Patronymic = NameTextBox.Text,
                    login = NameTextBox.Text,
                    password = NameTextBox.Text,
                    id_role = 1,
                    IsDelete = true

                };
                Group_student group = new Group_student()
                {
                    Name = _cat.ToString()

                };


                App.Connetction.Client.Add(client);
                App.Connetction.Group_student.Add(group);



                App.Connetction.SaveChanges();
                MessageBox.Show("Добавление произошло  успешно ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

    

