using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Identity.Domains.Entities;

namespace ShoppingSystem.Identity.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User,IdentityRole,string>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
