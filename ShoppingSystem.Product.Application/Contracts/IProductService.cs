namespace ShoppingSystem.Product.Application;

public interface IProductService
{
    Domain.Entities.Product GetProduct(int id);
    List<Domain.Entities.Product> GetProducts();
    bool AddProduct(Domain.Entities.Product product);
}
