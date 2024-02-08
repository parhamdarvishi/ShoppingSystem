using ShoppingSystem.Content.Application.Dtos.Content;

namespace ShoppingSystem.Content.Api.Profile;

public class ContentProfile : AutoMapper.Profile
{
    public ContentProfile()
    {
        CreateMap<AddContentDto, Domain.Entities.Content>();
        CreateMap<UpdateContentDto, Domain.Entities.Content>();
    }
}
