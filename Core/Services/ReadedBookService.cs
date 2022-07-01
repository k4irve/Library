using Core.Entities;

namespace Core.Services;

public interface IReadedBookService
{
    void Create(string title,sbyte rate);
    void Update(int id, string title,sbyte rate);
    void Delete(int id);
    ReadedBook GetById(int id);
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