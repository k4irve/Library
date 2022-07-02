using Core.Entities;

namespace Core.Services;

public interface IBestAuthorService
{
    /// <summary>
    /// Method to create an object that is added to a database table
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    void Create(string firstName,string lastName);
    /// <summary>
    /// Method for editing an object that is retrieved from a table in the database and then saved in it
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    void Update(int id, string firstName,string lastName);
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
    BestAuthor GetById(int id);
    /// <summary>
    /// Method that retrieves all records from a table
    /// </summary>
    /// <returns></returns>
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