namespace ShppingSystem.Product.Api.Businesses
{
    public interface IProductBusiness
    {
        Models.Product GetProduct(int id);
        List<Models.Product> GetProducts();
        bool AddProduct(Models.Product product);
    }
}
