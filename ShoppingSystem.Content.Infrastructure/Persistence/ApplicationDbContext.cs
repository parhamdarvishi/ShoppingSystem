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

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200);
        configurationBuilder.Properties<string>().AreUnicode(false);
    }

    public DbSet<Domain.Entities.Content> Contents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");

        //For configuration
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //For Seeder
        builder.RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly);

        base.OnModelCreating(builder);
    }
}
