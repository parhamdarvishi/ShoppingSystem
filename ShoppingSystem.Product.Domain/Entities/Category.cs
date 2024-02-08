using ShoppingSystem.Product.Domain.Contracts;

namespace ShoppingSystem.Product.Domain.Entities;

public class Category : FullBaseEntity<int>
{
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}
