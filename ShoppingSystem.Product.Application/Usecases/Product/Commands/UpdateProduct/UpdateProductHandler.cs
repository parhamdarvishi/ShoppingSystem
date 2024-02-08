using AutoMapper;
using MediatR;
using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Response<int>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Response<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<UpdateProductCommand, Domain.Entities.Product>(request);
        await _repository.AddAsync(product);

        return Response.Success<int>(product.Id);
    }
}
