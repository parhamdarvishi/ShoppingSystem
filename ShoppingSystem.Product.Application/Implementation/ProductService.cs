using ShoppingSystem.Product.Infrastructure.Contracts;

namespace ShoppingSystem.Product.Application;

public class ProductService : IProductService
{
    private readonly IProductContext _context;
    public ProductService(IProductContext context)
    {
        _context = context;
    }

    public bool AddProduct(Domain.Entities.Product product)
    {
        throw new NotImplementedException();
    }

    public Domain.Entities.Product GetProduct(int id)
    {
        return _context.Set<Domain.Entities.Product>().FirstOrDefault(x => x.Id == id);
    }

    public List<Domain.Entities.Product> GetProducts()
    {
        return _context.Set<Domain.Entities.Product>().ToList();
    }


}
