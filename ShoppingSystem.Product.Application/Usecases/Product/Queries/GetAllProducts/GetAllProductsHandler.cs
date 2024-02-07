using AutoMapper;
using MediatR;
using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Response<object>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Response<object>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _repository.GetAll();
        return Response.Success<object>(products);
    }
}
