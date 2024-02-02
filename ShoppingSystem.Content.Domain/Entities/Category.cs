namespace ShoppingSystem.Content.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreateAt { get; set; }

}
