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
        _service.Create(Title.Text, Double.Parse(Amount.Text));
        GetAll();
    }
}