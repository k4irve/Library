using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BookToReadView : UserControl
{
    private readonly BookToReadService _service;
    public BookToReadView()
    {
        InitializeComponent();
        _service = new BookToReadService();
        GetAll();
    }

    private void GetAll()
    {
        View.ItemsSource = _service.GetAll();
    }

    private void Delete(object sender, RoutedEventArgs e)
    {
        dynamic item = ((Button) sender).DataContext;
        _service.Delete(item.Id);
        GetAll();
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        if (Title.Text != "")
        {
            _service.Create(Title.Text);
            GetAll();
            Title.Text = "";
        }
        else
        {
            MessageBox.Show("Invalid input!");
        }
    }
}