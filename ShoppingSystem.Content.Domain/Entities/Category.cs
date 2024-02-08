using ShoppingSystem.Contant.Domain.Contracts;

namespace ShoppingSystem.Content.Domain.Entities;

public class Category: FullBaseEntity<int>
{
    public string Name { get; set; }

    public ICollection<Content> Contents { get; set; }
}
