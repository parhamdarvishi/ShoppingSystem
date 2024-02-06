using MediatR;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IQueryable<Domain.Entities.Product>>
{
    public Task<IQueryable<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
