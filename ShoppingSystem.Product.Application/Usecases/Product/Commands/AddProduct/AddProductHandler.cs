using AutoMapper;
using MediatR;
using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Commands.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand, Response<int>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public AddProductHandler(IProductRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Response<int>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<AddProductCommand, Domain.Entities.Product>(request);
        _repository.Add(product);

        return Response.Success<int>(product.Id);
    }
}
