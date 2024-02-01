namespace ShoppingSystem.Product.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();

    TEntity GetById(int id);

    bool Add(TEntity entity);

    bool Update(TEntity entity);

    bool Delete(TEntity entity);
}
