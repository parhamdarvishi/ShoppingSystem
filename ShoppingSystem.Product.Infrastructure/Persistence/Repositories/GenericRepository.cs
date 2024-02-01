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

    public bool Add(TEntity entity)
    {
        //First Way
        //_dbContext.Add(entity);

        //Second way
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public TEntity GetById(int id)
    {
        //return  _dbContext.Set<TEntity>()
        //             .AsNoTracking()
        //             .FirstOrDefaultAsync(e => e.Id == id);

        throw new NotImplementedException();
    }

}
