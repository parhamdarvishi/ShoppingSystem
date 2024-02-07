using MediatR;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
