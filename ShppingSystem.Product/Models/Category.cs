namespace ShppingSystem.Product.Api.Models;

public class Category
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationAt { get; set; }
}
