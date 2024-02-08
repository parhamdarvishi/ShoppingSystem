
using ShoppingSystem.Contant.Domain.Contracts;

namespace ShoppingSystem.Content.Domain.Entities;

public class Content: FullBaseEntity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string BannerImagePath { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeyword { get; set; }

    public int MasterId { get; set; }
    public Master Master { get; set; }

    public ICollection<Category> Categories { get; set; }
    public ICollection<ContentAttachment> ContentAttachments { get; set; }
}
