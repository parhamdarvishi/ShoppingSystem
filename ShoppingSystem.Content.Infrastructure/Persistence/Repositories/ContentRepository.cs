using ShoppingSystem.Content.Domain.Repositories;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Repositories;

public class ContentRepository : GenericRepository<Domain.Entities.Content>, IContentRepository
{
    public ContentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
