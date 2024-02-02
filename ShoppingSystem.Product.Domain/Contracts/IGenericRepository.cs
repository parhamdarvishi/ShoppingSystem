namespace ShoppingSystem.Product.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task<bool> AddAsync(TEntity entity);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(TEntity entity);
}
