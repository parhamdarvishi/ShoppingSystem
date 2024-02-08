using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Product.Domain.Contracts;

namespace ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(TEntity entity)
    {
        //First Way
        //_dbContext.Add(entity);

        //Second way
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        //return  _dbContext.Set<TEntity>()
        //             .AsNoTracking()
        //             .FirstOrDefaultAsync(e => e.Id == id);

        throw new NotImplementedException();
    }

}
