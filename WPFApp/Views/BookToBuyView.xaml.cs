using System;
using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BookToBuyView : UserControl
{
    private readonly IBookToBuyService _service;
    public BookToBuyView()
    {
        InitializeComponent();
        _service = new BookToBuyService();
        GetAll();
    }

    /// <summary>
    /// Method that refreshes the list items in the view
    /// </summary>
    private void GetAll()
    {
        View.ItemsSource = _service.GetAll();
    }

    /// <summary>
    /// Method that deletes a given record from a table using the service
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Delete(object sender, RoutedEventArgs e)
    {
        dynamic item = ((Button) sender).DataContext;
        _service.Delete(item.Id);
        GetAll();
    }

    /// <summary>
    /// Method that validates the input data and then, if valid, adds the record using the service
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Add(object sender, RoutedEventArgs e)
    {
        double output;
        if (Title.Text != "" && Amount.Text != "" && double.TryParse(Amount.Text, out output))
        {
            _service.Create(Title.Text, Double.Parse(Amount.Text),Author.Text,Publisher.Text,PublicationDate.SelectedDate.Value,Int32.Parse(Pages.Text));
            GetAll();
            Title.Text = "";
            Amount.Text = "";
            Author.Text = "";
            Publisher.Text = "";
            PublicationDate.Text = "";
            Pages.Text = "";
        }
        else
        {
            MessageBox.Show("Invalid input!");
        }
        
    }
}