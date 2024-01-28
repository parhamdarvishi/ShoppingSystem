using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Product.Domain.Contracts;
using ShoppingSystem.Product.Domain.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

public class BrandRepository : IGenericRepository<Brand>
{
    private ProductContext _context;
    public BrandRepository(ProductContext context)
    {
        _context = context;
    }

    public bool Add(Brand entity)
    {
        _context.Brands.Add(entity);
        return true;
    }

    public bool Delete(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand is { })
        {
            _context.Brands.Remove(brand);
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Brand> GetAll()
    {
        var brands = _context.Brands.ToList();
        return brands;
    }

    public Brand GetById(int id)
    {
        var brand = _context.Brands.Find(id);
        return brand;
    }

    public Brand Select(Expression<Func<Brand, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Update(Brand entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return true;
    }
}
