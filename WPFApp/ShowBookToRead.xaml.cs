using System;
using System.Windows;
using Core.Services;

namespace WPFApp;

public partial class ShowBookToRead : Window
{
    private readonly IBookToReadService _service;
    public ShowBookToRead(int id)
    {
        InitializeComponent();
        _service = new BookToReadService();
        GetInfo(id);
    }

    private void GetInfo(int id)
    {
        var item = _service.GetById(id);
        Title.Text = item.Title;
        Author.Text = item.Author;
        Pages.Text = item.Pages.ToString();
        PublicationDate.Text = item.PublicationDate.ToString();
        Publisher.Text = item.Publisher;
    }
    
}