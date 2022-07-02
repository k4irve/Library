using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core;
/// <summary>
/// Class which has a database context
/// </summary>
public class AppDbContext:DbContext
{
    public AppDbContext()
    {
    }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    /// <summary>
    /// ReadedBooks table
    /// </summary>
    public DbSet<ReadedBook> ReadedBooks { get; set; }
    /// <summary>
    /// BooksToBuy table
    /// </summary>
    public DbSet<BookToBuy> BooksToBuy{ get; set; }
    /// <summary>
    /// BooksToRead table
    /// </summary>
    public DbSet<BookToRead> BooksToRead { get; set; }
    /// <summary>
    /// BestAuthors table
    /// </summary>
    public DbSet<BestAuthor> BestAuthors { get; set; }
    
    /// <summary>
    /// Method that enforces having an id for each object
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReadedBook>().HasKey(x => x.Id);
        modelBuilder.Entity<BookToBuy>().HasKey(x => x.Id);
        modelBuilder.Entity<BookToRead>().HasKey(x => x.Id);
        modelBuilder.Entity<BestAuthor>().HasKey(x => x.Id);
    }
}