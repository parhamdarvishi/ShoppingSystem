using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Businesses;

public class ProductBusiness : IProductBusiness
{
    private readonly ProductContext _context;
    public ProductBusiness(ProductContext context)
    {
        _context = context;
    }

    public Models.Product GetProduct(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public List<Models.Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}
