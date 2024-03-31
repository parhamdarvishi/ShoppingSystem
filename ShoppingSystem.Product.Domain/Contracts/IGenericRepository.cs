using System.Linq.Expressions;

namespace ShoppingSystem.Product.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetAllAsync();

    Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression);

    Task<bool> AddAsync(TEntity entity);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(TEntity entity);
}
