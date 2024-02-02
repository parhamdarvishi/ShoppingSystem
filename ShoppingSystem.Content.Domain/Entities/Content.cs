
namespace ShoppingSystem.Content.Domain.Entities;

public class Content
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string BannerImagePath { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeyword { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }
}
