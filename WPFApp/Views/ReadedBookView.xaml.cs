using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class ReadedBookView : UserControl
{
    private readonly IReadedBookService _service;
    public ReadedBookView()
    {
        InitializeComponent();
        _service = new ReadedBookService();
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
        int[] checking = new int[10] {1,2,3,4,5,6,7,8,9,10};

        if (Title.Text != "" && Rate.Text != "" && checking.Contains(SByte.Parse(Rate.Text)))
        {
            _service.Create(Title.Text, SByte.Parse(Rate.Text));
            GetAll();
            Title.Text = "";
            Rate.Text = "";
        }
        else
        {
            MessageBox.Show("Invalid input!");
        }
    }
}