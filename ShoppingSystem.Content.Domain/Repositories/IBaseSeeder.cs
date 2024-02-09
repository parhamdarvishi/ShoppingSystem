namespace ShoppingSystem.Content.Domain.Repositories;

public interface IBaseSeeder<T> where T : class
{
    IEnumerable<T> GetSeedData();
}
