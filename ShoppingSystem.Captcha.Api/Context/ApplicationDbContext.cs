using Microsoft.EntityFrameworkCore;

namespace ShoppingSystem.Captcha.Api.Context;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Entities.Captcha> Captchas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
}