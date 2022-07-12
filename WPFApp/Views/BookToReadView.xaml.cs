using System;
using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BookToReadView : UserControl
{
    private readonly IBookToReadService _service;
    public BookToReadView()
    {
        InitializeComponent();
        _service = new BookToReadService();
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
        if (Title.Text != "")
        {
            _service.Create(Title.Text,Author.Text,Publisher.Text,PublicationDate.SelectedDate.Value,Int32.Parse(Pages.Text));
            GetAll();
            Title.Text = "";
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