using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система.PageAppWorker
{
    /// <summary>
    /// Логика взаимодействия для PageShowBooksW.xaml
    /// </summary>
    public partial class PageShowBooksW : Page
    {
        public static List<Book> Books { get; set; }
        public static List<location> locations = new List<location>();
        public static List<Discipline> disciplines = new List<Discipline>();
        public static List<Author> authors = new List<Author>();
        public static List<Date_of_publication> date_Of_Publications = new List<Date_of_publication>();
        public ObservableCollection<Book> Books1 { get; set; }
        public ICollectionView BooksView { get; set; }
        public PageShowBooksW()
        {
            InitializeComponent();
            ListInfo.ItemsSource = App.Connetction.Book.ToList();
            Books = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == true).ToList());
            Books = new List<Book>(BdConnection.libraryEntities.Book.ToList());
            date_Of_Publications = new List<Date_of_publication>(BdConnection.libraryEntities.Date_of_publication.ToList());
            authors = new List<Author>(BdConnection.libraryEntities.Author.ToList());
            locations = new List<location>(BdConnection.libraryEntities.location.ToList());
            disciplines = new List<Discipline>(BdConnection.libraryEntities.Discipline.ToList());
            Books.Insert(0, new Book() { id = -1, books = "Вывести всех" }); //для обратного вывода списка от combobox
            
            this.DataContext = this;
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageEdit());
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Book;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BdConnection.libraryEntities.SaveChanges();
            ListInfo.ItemsSource = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == true).ToList());
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = Books.Where(p => p.books.ToLower().Contains(filterText)).ToList();
            ListInfo.ItemsSource = new ObservableCollection<Book>(filteredProducts);
        }

        private void ListInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Gropscombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grouosirt = Gropscombo.SelectedItem as Discipline;
            if (grouosirt.id != -1)
            {

                ListInfo.ItemsSource = new List<location>(BdConnection.libraryEntities.location.Where(i => i.id_discipline == grouosirt.id).ToList()); // филтрация по группам
            }
            else
            {
                ListInfo.ItemsSource = new List<location>(BdConnection.libraryEntities.location.ToList());
            }
        }
    }
}
