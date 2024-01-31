using ShoppingSystem.Product.Domain.Contracts;

namespace ShoppingSystem.Product.Application;

public interface IProductService:IGenericRepository<Domain.Entities.Product>
{

}
