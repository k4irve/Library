using Core.Entities;

namespace Core.Services;

public class BookToReadService
{
    private readonly AppDbContext _context;
    
    public BookToReadService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string title)
    {
        _context.BooksToRead.Add(new BookToRead() {Title = title});
    }

    public void Update(int id, string title)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        book.Title = title;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        _context.BooksToRead.Remove(book);
    }

    public BookToRead GetById(int id)
    {
        return _context.BooksToRead.FirstOrDefault(x => x.Id == id);
    }

    public List<BookToRead> GetAll()
    {
        var books = _context.BooksToRead.ToList();
        return books;
    }
    
}