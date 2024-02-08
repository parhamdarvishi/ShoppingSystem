using ShoppingSystem.Product.Domain.Contracts;

namespace ShoppingSystem.Product.Domain.Entities;

public class Product : FullBaseEntity<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public ICollection<Category> Categories { get; set; }
}
