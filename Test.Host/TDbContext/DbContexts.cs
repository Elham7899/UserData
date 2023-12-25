using Microsoft.EntityFrameworkCore;
using Test.Host.Mappings;
using Test.Host.Models;

namespace Test.Host.TDbContext;

public class DbContexts : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Child> Children { get; set; }

    public DbContexts(DbContextOptions options):base(options)
    {
        
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
	}
}
