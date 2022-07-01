using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core;

public class ContextFactory:IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args = null)
    {
        var opt = new DbContextOptionsBuilder<AppDbContext>();
        opt.UseSqlServer("Server=.; Database=Library; Trusted_Connection=True");
        return new AppDbContext(opt.Options);
    }
}