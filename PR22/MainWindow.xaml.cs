using PR22;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PR_22
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; }
        public Book SelectedBook { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Books = new ObservableCollection<Book>
            {
                new Book { Title = "Война и мир", Author = "Л.Н. Толстой", Count = 5, Taken = 1, Cover = @"C:\Users\ikoro\OneDrive\Изображения\23158197213.jpg" },
                new Book { Title = "Преступление и наказание", Author = "Ф.М. Достоевский", Count = 3, Taken = 0, Cover = @"C:\Users\ikoro\OneDrive\Изображения\245912971501028.jpg" },
                new Book { Title = "Мастер и Маргарита", Author = "М.А. Булгаков", Count = 2, Taken = 2, Cover = @"C:\Users\ikoro\OneDrive\Изображения\1289491277b87124.jpg"}
            };

            DataContext = this;
        }
        private void BooksPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksPanel.SelectedItem is Book book)
            {
                SelectedBook = book;
                TitleBox.Text = book.Title;
                AuthorBox.Text = book.Author;
                CountBox.Text = book.Count.ToString();
                TakenBox.Text = book.Taken.ToString();
                StatusText.Text = book.Status;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book { Title = "Новая книга", Author = "Автор", Count = 1, Taken = 0 });
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
            }
        }
        private void GiveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBook != null && SelectedBook.Count > 0)
            {
                SelectedBook.Count--;
                SelectedBook.Taken++;

                
                RefreshUI();
            }
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBook != null && SelectedBook.Taken > 0)
            {
                SelectedBook.Taken--;
                SelectedBook.Count++;
                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            if (SelectedBook != null)
            {
                int index = Books.IndexOf(SelectedBook);
                Books[index] = Books[index];

                CountBox.Text = SelectedBook.Count.ToString();
                TakenBox.Text = SelectedBook.Taken.ToString();
                StatusText.Text = SelectedBook.Status;
            }
        }
    }
}