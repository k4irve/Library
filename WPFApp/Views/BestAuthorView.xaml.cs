using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BestAuthorView : UserControl
{
    private readonly BestAuthorService _service;
    public BestAuthorView()
    {
        InitializeComponent();
        _service = new BestAuthorService();
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
        if (FirstName.Text != "" && LastName.Text != "")
        {
            _service.Create(FirstName.Text, LastName.Text);
            GetAll();
            FirstName.Text = "";
            LastName.Text = "";
        }
        else
        {
            MessageBox.Show("Invalid input!");
        }
    }
}