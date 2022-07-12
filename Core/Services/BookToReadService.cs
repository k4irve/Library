using Core.Entities;

namespace Core.Services;

public interface IBookToReadService
{
    /// <summary>
    /// Method to create an object that is added to a database table
    /// </summary>
    /// <param name="title"></param>
    void Create(string title,string author,string publisher,DateTime publicationDate,int pages);
    /// <summary>
    /// method for editing an object that is retrieved from a table in the database and then saved in it
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    void Update(int id, string title,string author,string publisher,DateTime publicationDate,int pages);
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
    BookToRead GetById(int id);
    /// <summary>
    /// Method that retrieves all records from a table
    /// </summary>
    /// <returns></returns>
    List<BookToRead> GetAll();
}

public class BookToReadService : IBookToReadService
{
    private readonly AppDbContext _context;
    
    public BookToReadService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string title,string author,string publisher,DateTime publicationDate,int pages)
    {
        _context.BooksToRead.Add(new BookToRead() {Title = title,Author = author,Publisher = publisher,PublicationDate = publicationDate,Pages = pages});
        _context.SaveChanges();
    }

    public void Update(int id, string title,string author,string publisher,DateTime publicationDate,int pages)
    {
        var book = _context.BooksToRead.FirstOrDefault(x => x.Id == id);
        if (book == null) throw new Exception("Null reference");
        book.Title = title;
        book.Author = author;
        book.Publisher = publisher;
        book.PublicationDate = publicationDate;
        book.Pages = pages;
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