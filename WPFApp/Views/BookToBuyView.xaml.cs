using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BookToBuyView : UserControl
{
    private readonly IBookToBuyService _service;

    private int sortByPrice = 1;

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
        int outputint;
        if (Title.Text != "" && Amount.Text != "" && double.TryParse(Amount.Text, out output) && int.TryParse(Pages.Text, out outputint) && Author.Text != "" && Publisher.Text != "" && PublicationDate.Text != "" )
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

    private void SortByPrice(object sender, RoutedEventArgs e)
    {
        if (sortByPrice == 1)
        {
            View.ItemsSource = _service.GetAll().OrderBy(x => x.Amount);
            sortByPrice = 2;
            return;
        }

        if (sortByPrice == 2)
        {
            View.ItemsSource = _service.GetAll().OrderByDescending(x => x.Amount);
            sortByPrice = 1;
            return;
        }
    }
}