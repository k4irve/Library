using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {
    }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<ReadedBook> ReadedBooks { get; set; }
    public DbSet<BookToBuy> BooksToBuy{ get; set; }
    public DbSet<BookToRead> BooksToRead { get; set; }
    public DbSet<BestAuthor> BestAuthors { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReadedBook>().HasKey(x => x.Id);
        modelBuilder.Entity<BookToBuy>().HasKey(x => x.Id);
        modelBuilder.Entity<BookToRead>().HasKey(x => x.Id);
        modelBuilder.Entity<BestAuthor>().HasKey(x => x.Id);
    }
}