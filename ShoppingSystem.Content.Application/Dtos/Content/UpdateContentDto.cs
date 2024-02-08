namespace ShoppingSystem.Content.Application.Dtos.Content;

public record UpdateContentDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string BannerImagePath { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeyword { get; set; }
    public int MasterId { get; set; }
}
