namespace ShoppingSystem.Content.Application.Services;

public interface IContentService
{
    Task<IList<Domain.Entities.Content>> GetAllContentsAsync();

    Task<Domain.Entities.Content> GetContentByIdAsync(int id);

    Task<bool> AddContentAsync(Domain.Entities.Content entity);

    Task<bool> UpdateContentAsync(Domain.Entities.Content entity);

    Task<bool> DeleteContentAsync(int id);
}
