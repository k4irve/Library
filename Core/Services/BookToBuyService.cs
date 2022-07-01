using Core.Entities;

namespace Core.Services;

public interface IBookToBuyService
{
    void Create(string title,double amount);
    void Update(int id, string title,double amount);
    void Delete(int id);
    BookToBuy GetById(int id);
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