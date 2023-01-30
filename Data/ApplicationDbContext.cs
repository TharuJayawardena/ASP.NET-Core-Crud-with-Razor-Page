using BulkyBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Catergory> Catergory { get; set; }
}
