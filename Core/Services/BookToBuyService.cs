using Core.Entities;

namespace Core.Services;

public interface IBookToBuyService
{
    /// <summary>
    /// Method to create an object that is added to a database table
    /// </summary>
    /// <param name="title"></param>
    /// <param name="amount"></param>
    void Create(string title,double amount);
    /// <summary>
    /// method for editing an object that is retrieved from a table in the database and then saved in it
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="amount"></param>
    void Update(int id, string title,double amount);
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
    BookToBuy GetById(int id);
    /// <summary>
    /// Method that retrieves all records from a table
    /// </summary>
    /// <returns></returns>
    List<BookToBuy> GetAll();
}

public class BookToBuyService : IBookToBuyService
{
    private readonly AppDbContext _context;
    
    public BookToBuyService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string title,double amount)
    {
        _context.BooksToBuy.Add(new BookToBuy() {Title = title,Amount = amount });
        _context.SaveChanges();
    }

    public void Update(int id, string title,double amount)
    {
        var book = _context.BooksToBuy.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        book.Amount = amount;
        book.Title = title;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.BooksToBuy.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        _context.BooksToBuy.Remove(book);
        _context.SaveChanges();
    }

    public BookToBuy GetById(int id)
    {
        var book = _context.BooksToBuy.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        return book;
    }

    public List<BookToBuy> GetAll()
    {
        var books = _context.BooksToBuy.ToList();
        return books;
    }
}