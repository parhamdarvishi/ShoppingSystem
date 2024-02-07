using MediatR;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Application.Usecases.Product.Commands.AddProduct;

public record AddProductCommand : IRequest<Response<int>>
{
    public string name { get; set; }
    public decimal price { get; set; }
    public string description { get; set; }
}
