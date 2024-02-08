using MediatR;
using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Response<object>>
{

    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<object>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _repository.GetByIdAsync(id: request.id);
        return Response.Success<object>(product);
    }
}
