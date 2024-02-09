using ShoppingSystem.Content.Domain.Repositories;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Seeder;

public class ContentSeeder : IBaseSeeder<Domain.Entities.Content>
{
    public IEnumerable<Domain.Entities.Content> GetSeedData()
    {
        return new[]
        {
            new Domain.Entities.Content()
            {
                Description = "This is Test Description",
                MasterId =  1,
                Title  = "C# pro",
                Link = "/CSharp",
                MetaDescription = "This is Meta Description for c#",
                MetaKeyword = "c#,Software"
            }
        };
    }
}
