using System.Linq.Expressions;

namespace ShoppingSystem.Product.Domain.Contracts;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    bool Delete(int id);
    bool Add(T entity);
    bool Update(T entity);
    public T Select(Expression<Func<T, bool>> predicate);
}
