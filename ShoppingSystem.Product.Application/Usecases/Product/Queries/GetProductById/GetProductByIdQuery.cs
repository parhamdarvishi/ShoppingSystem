using MediatR;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries.GetProductById;

public record GetProductByIdQuery(int id) : IRequest<Response<object>>;
