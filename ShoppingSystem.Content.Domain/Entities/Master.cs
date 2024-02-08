using ShoppingSystem.Contant.Domain.Contracts;

namespace ShoppingSystem.Content.Domain.Entities;

public class Master: FullBaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string LinkedInLink { get; set; }
    public string YoutubeLink { get; set; }
    public string TelegramLink { get; set; }
    public string InstgramLink { get; set; }
}
