using Microsoft.EntityFrameworkCore;

namespace ShppingSystem.Product.Api.Models;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }

}
