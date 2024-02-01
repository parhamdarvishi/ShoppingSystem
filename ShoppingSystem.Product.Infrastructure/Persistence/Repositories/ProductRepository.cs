using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Product.Domain.Contracts;
using System.Linq.Expressions;

namespace ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Domain.Entities.Product>,IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Domain.Entities.Product GetById(int id)
    {
        var product = _dbContext.Products.Find(id);
        return product;
    }

}
