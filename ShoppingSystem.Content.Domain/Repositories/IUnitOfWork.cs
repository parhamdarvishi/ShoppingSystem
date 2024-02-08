
using ShoppingSystem.Content.Domain.Contracts;

namespace ShoppingSystem.Content.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;

    int Save();

}
