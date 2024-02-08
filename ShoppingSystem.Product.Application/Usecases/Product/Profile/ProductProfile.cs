using AutoMapper;
using ShoppingSystem.Product.Application.Usecases.Product.Commands.AddProduct;
using ShoppingSystem.Product.Application.Usecases.Product.Commands.UpdateProduct;

namespace ShoppingSystem.Product.Application.Usecases.Product;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductCommand, Domain.Entities.Product>();
        CreateMap<UpdateProductCommand, Domain.Entities.Product>();
    }
}
