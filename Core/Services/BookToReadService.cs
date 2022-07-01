using Core.Entities;

namespace Core.Services;

public interface IBookToReadService
{
    void Create(string title);
    void Update(int id, string title);
    void Delete(int id);
    BookToRead GetById(int id);
    List<BookToRead> GetAll();
}

public class BookToReadService : IBookToReadService
{
    private readonly AppDbContext _context;
    
    public BookToReadService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string title)
    {
        _context.BooksToRead.Add(new BookToRead() {Title = title});
        _context.SaveChanges();
    }

    public void Update(int id, string title)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        book.Title = title;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        _context.BooksToRead.Remove(book);
        _context.SaveChanges();
    }

    public BookToRead GetById(int id)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        return book;
    }

    public List<BookToRead> GetAll()
    {
        var books = _context.BooksToRead.ToList();
        return books;
    }
    
}