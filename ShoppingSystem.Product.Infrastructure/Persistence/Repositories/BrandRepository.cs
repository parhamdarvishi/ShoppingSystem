using ShoppingSystem.Product.Application.Contracts;

namespace ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

public class BrandRepository : GenericRepository<Domain.Entities.Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext context) : base(context)
    {
    }

}
