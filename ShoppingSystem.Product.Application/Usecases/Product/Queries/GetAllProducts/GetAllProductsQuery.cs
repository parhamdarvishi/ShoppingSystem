using MediatR;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<Response<object>>;
