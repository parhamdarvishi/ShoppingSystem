using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Product.Domain.Entities;
using ShoppingSystem.Product.Infrastructure.Contracts;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Infrastructure.Persistence;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Domain.Entities.Product> Products { get; set; }

    Task<Response> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
