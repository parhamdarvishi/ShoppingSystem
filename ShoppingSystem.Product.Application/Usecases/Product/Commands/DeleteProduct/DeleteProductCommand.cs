using MediatR;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Commands.DeleteProduct;

public record DeleteProductCommand(int id) : IRequest<Response<object>>;
