using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core;
/// <summary>
/// Method that creates an object of the AppDbContext
/// </summary>
public class ContextFactory:IDesignTimeDbContextFactory<AppDbContext>
{ 
    /// <summary>
     /// Method that creates an object of the AppDbContext class, i.e. creates a connection to the database
     /// </summary>
     /// <param name="args"></param>
     /// <returns></returns>
    public AppDbContext CreateDbContext(string[] args = null)
    {
        var opt = new DbContextOptionsBuilder<AppDbContext>();
        opt.UseSqlServer("Server=.; Database=Library; Trusted_Connection=True");
        return new AppDbContext(opt.Options);
    }
}