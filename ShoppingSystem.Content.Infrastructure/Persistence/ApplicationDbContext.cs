using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Content.Domain.Repositories;
using ShoppingSystem.Content.Infrastructure.Persistence.Extensions;
using System.Reflection;

namespace ShoppingSystem.Content.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Content> Contents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //For configuration
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //For Seeder
        builder.RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly);

        base.OnModelCreating(builder);
    }
}
