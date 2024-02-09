using ShoppingSystem.Content.Domain.Entities;
using ShoppingSystem.Content.Domain.Repositories;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Seeder;

public class CategorySeeder : IBaseSeeder<Category>
{
    public IEnumerable<Category> GetSeedData()
    {
        return new[]
        {
            new Category(){ Name = "C#"}
        };
    }
}
