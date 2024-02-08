using ShoppingSystem.Contant.Domain.Contracts;

namespace ShoppingSystem.Content.Domain.Entities;

public class ContentAttachment: FullBaseEntity<int>
{
    public string downloadToken { get; set; }
    public string downloadPath { get; set; }
}
