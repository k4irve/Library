﻿using System.Windows;
using System.Windows.Controls;
using Core.Services;

namespace WPFApp.Views;

public partial class BestAuthorView : UserControl
{
    private readonly IBestAuthorService _service;
    public BestAuthorView()
    {
        InitializeComponent();
        _service = new BestAuthorService();
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