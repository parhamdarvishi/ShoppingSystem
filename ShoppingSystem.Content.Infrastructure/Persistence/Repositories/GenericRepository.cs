using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Content.Domain.Contracts;


namespace ShoppingSystem.Content.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<bool> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return true;
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return true;
    }
}
