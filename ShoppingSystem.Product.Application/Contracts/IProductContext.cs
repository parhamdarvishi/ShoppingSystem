using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Infrastructure.Contracts;

public interface IProductContext
{
    Task<Response> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
