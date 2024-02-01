using AutoMapper;
using ShoppingSystem.Product.Api.Dtos;
using ShppingSystem.Product.Api.Dtos;

namespace ShoppingSystem.Product.Api.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductDto, Domain.Entities.Product>();
        CreateMap<UpdateProductDto, Domain.Entities.Product>();
    }
}
