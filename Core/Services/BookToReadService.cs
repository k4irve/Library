namespace Core.Services;

public class BookToReadService
{
    private readonly AppDbContext _context;
    
    public BookToReadService()
    {
        _context = new ContextFactory().CreateDbContext();
    }
    
}