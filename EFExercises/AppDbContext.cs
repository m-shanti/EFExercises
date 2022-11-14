using Microsoft.EntityFrameworkCore;

namespace EFExercises;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Table> MyData => Set<Table>();
}