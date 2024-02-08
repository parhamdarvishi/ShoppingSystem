using ShoppingSystem.Content.Domain.Repositories;

namespace ShoppingSystem.Content.Application.Services.Implementation;

public class ContentService : IContentService
{
    public IUnitOfWork _unitOfWork;

    public ContentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<bool> AddContentAsync(Domain.Entities.Content entity)
    {
        await _unitOfWork.Repository<Domain.Entities.Content>().AddAsync(entity);
        var result = _unitOfWork.Save();
        return result > 0 ? true : false;
    }

    public async Task<bool> DeleteContentAsync(int id)
    {
        var content = await _unitOfWork.Repository<Domain.Entities.Content>().GetByIdAsync(id);
        if (content != null)
        {
            await _unitOfWork.Repository<Domain.Entities.Content>().DeleteAsync(content);
            var result = _unitOfWork.Save();
            return result > 0 ? true : false;
        }
        else
        {
            return false;
        }
    }

    public async Task<IList<Domain.Entities.Content>> GetAllContentsAsync()
    {
        var contents = await _unitOfWork.Repository<Domain.Entities.Content>().GetAllAsync();
        return contents;
    }

    public async Task<Domain.Entities.Content> GetContentByIdAsync(int id)
    {
        var productDetails = await _unitOfWork.Repository<Domain.Entities.Content>().GetByIdAsync(id);
        if (productDetails != null)
            return productDetails;
        return null;
    }

    public async Task<bool> UpdateContentAsync(Domain.Entities.Content entity)
    {
        var content = await _unitOfWork.Repository<Domain.Entities.Content>().GetByIdAsync(entity.Id);
        if (content != null)
        {
            content.Description = entity.Description;
            content.MetaDescription = entity.MetaDescription;
            content.BannerImagePath = entity.BannerImagePath;

            await _unitOfWork.Repository<Domain.Entities.Content>().UpdateAsync(content);

            var result = _unitOfWork.Save();

            return result > 0 ? true : false;
        }
        return false;
    }
}
