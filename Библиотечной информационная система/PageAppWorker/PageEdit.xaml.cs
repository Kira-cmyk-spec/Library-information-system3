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
using Библиотечной_информационная_система.ClassApp;
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система.PageAppWorker
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public static List<Book> books { get; set; }
        public ObservableCollection<Book> books1 { get; set; }
        public static List<Discipline> disciplines { get; set; }
        public static List<Author> authors { get; set; }
        public static List<location> locations { get; set; }
        public static List<Date_of_publication> date_Of_Publications { get; set; }
        public PageEdit()
        {
            InitializeComponent();
            this.DataContext = App.Connetction.Book.Where(z => z.id == Class_Book.CorrBook.id).FirstOrDefault();
            this.DataContext = App.Connetction.Discipline.Where(z => z.id == Class_Discipline.Corrdiscipline.id).FirstOrDefault();
            this.DataContext = App.Connetction.Author.Where(z => z.id == Class_Author.CorrAuthor.id).FirstOrDefault();
            this.DataContext = App.Connetction.location.Where(z => z.id == Class_location.Corrlocation.id).FirstOrDefault();
            this.DataContext = App.Connetction.Date_of_publication.Where(z => z.id == Class_Date_of_publication.CorrDateOfPublication.id).FirstOrDefault();

        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
            NavigationService.Navigate(new PageAppWorker.PageShowBooksW());
        }
    }
}
