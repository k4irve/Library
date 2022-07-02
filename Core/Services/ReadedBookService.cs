﻿using Core.Entities;

namespace Core.Services;

public interface IReadedBookService
{
    /// <summary>
    /// Method to create an object that is added to a database table
    /// </summary>
    /// <param name="title"></param>
    /// <param name="rate"></param>
    void Create(string title,sbyte rate);
    /// <summary>
    /// method for editing an object that is retrieved from a table in the database and then saved in it
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="rate"></param>
    void Update(int id, string title,sbyte rate);
    /// <summary>
    /// Method that checks by id whether such an object exists in a table, and if it does, deletes it.
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    /// <summary>
    /// Method that retrieves a record by id from a table
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ReadedBook GetById(int id);
    /// <summary>
    /// Method that retrieves all records from a table
    /// </summary>
    /// <returns></returns>
    List<ReadedBook> GetAll();
}

public class ReadedBookService : IReadedBookService
{
    private readonly AppDbContext _context;
    
    public ReadedBookService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string title,sbyte rate)
    {
        _context.ReadedBooks.Add(new ReadedBook() {Title = title,Rate = rate });
        _context.SaveChanges();
    }

    public void Update(int id, string title,sbyte rate)
    {
        var book = _context.ReadedBooks.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        book.Rate = rate;
        book.Title = title;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.ReadedBooks.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        _context.ReadedBooks.Remove(book);
        _context.SaveChanges();
    }

    public ReadedBook GetById(int id)
    {
        var book = _context.ReadedBooks.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        return book;
    }

    public List<ReadedBook> GetAll()
    {
        var books = _context.ReadedBooks.ToList();
        return books;
    }
}