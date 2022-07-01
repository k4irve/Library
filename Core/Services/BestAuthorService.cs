using Core.Entities;

namespace Core.Services;

public interface IBestAuthorService
{
    void Create(string firstName,string lastName);
    void Update(int id, string firstName,string lastName);
    void Delete(int id);
    BestAuthor GetById(int id);
    List<BestAuthor> GetAll();
}

public class BestAuthorService : IBestAuthorService
{
    private readonly AppDbContext _context;
    
    public BestAuthorService()
    {
        _context = new ContextFactory().CreateDbContext();
    }

    public void Create(string firstName,string lastName)
    {
        _context.BestAuthors.Add(new BestAuthor() {FirstName = firstName,LastName = lastName });
        _context.SaveChanges();
    }

    public void Update(int id, string firstName,string lastName)
    {
        var author = _context.BestAuthors.FirstOrDefault(x => x.Id == id);
        if (author == null) throw new Exception("Null reference");
        author.FirstName = firstName;
        author.LastName = lastName;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var author = _context.BestAuthors.FirstOrDefault(x => x.Id == id);
        if (author == null) throw new Exception("Null reference");
        _context.BestAuthors.Remove(author);
        _context.SaveChanges();
    }

    public BestAuthor GetById(int id)
    {
        var author = _context.BestAuthors.FirstOrDefault(x => x.Id == id);
        if (author == null) throw new Exception("Null reference");
        return author;
    }

    public List<BestAuthor> GetAll()
    {
        var authors = _context.BestAuthors.ToList();
        return authors;
    }
}