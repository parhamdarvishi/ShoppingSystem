using ShoppingSystem.Product.Domain.Contracts;
using System.Linq.Expressions;

namespace ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

public class ProductRepository : IGenericRepository<Domain.Entities.Product>
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public bool Add(Domain.Entities.Product entity)
    {
        _context.Products.Add(entity);
        return true;
    }

    public bool Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is { })
        {
            _context.Products.Remove(product);
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Domain.Entities.Product> GetAll()
    {
        var products = _context.Products.ToList();
        return products;
    }

    public Domain.Entities.Product GetById(int id)
    {
        var product = _context.Products.Find(id);
        return product;
    }

    public Domain.Entities.Product Select(Expression<Func<Domain.Entities.Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Update(Domain.Entities.Product entity)
    {
        throw new NotImplementedException();
    }
}
