using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для PageAddBook.xaml
    /// </summary>
    public partial class PageAddBook : Page
    {
        public static List<Book> books { get; set; }
        public ObservableCollection<Book> books1 { get; set; }
        public static List<Discipline> disciplines { get; set; }
        public static List<Author> authors { get; set; }
        public static List<location> locations { get; set; }
        public static List<Date_of_publication> date_Of_Publications { get; set; }
        public PageAddBook()
        {
            InitializeComponent();

        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            try
            {
                var _cat = disciplinComboBox.SelectedItem as Discipline;

                Book items = new Book()
                {
                    books = bookTextBox.Text,
                    IsDelete = true

                };
                Date_of_publication data = new Date_of_publication()
                {
                    date_of_publication1 = dataTextBox.Text
                  
                };
                location location = new location()
                {
                    rack = Convert.ToInt32(RackTextBox),
                    sthelf = Convert.ToInt32(ShelftextBox),

                };
                Author author = new Author()
                {
                   Name = AuthorTextBox.Text

                };
             
                App.Connetction.Book.Add(items);
                App.Connetction.Date_of_publication.Add(data);
                App.Connetction.location.Add(location);
                App.Connetction.Author.Add(author);


                App.Connetction.SaveChanges();
                MessageBox.Show("Добавление произошло успешно ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
 }

