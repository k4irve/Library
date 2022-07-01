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
using WPFApp.ViewModels;
using WPFApp.Views;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BooksToRead(object sender, RoutedEventArgs e)
        {
            DataContext = new BooksToReadViewModel();
        }

        private void BooksToBuy(object sender, RoutedEventArgs e)
        {
            DataContext = new BooksToBuyViewModel();
        }

        private void ReadedBooks(object sender, RoutedEventArgs e)
        {
            DataContext = new ReadedBooksViewModel();
        }

        private void BestAuthors(object sender, RoutedEventArgs e)
        {
            DataContext = new BestAuthorsViewModel();
        }
        

        private void MainWindowButton(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowView();
        }
    }
}