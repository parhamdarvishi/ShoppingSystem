using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Contant.Domain.Contracts;
using ShoppingSystem.Content.Domain.Repositories;
using System.Reflection;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtension
{
    public static ModelBuilder RegisterAllSeeders(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var seederTypes = assemblies.SelectMany(a => a.GetTypes());

        foreach (var seederType in seederTypes)
        {
            var seeder = Activator.CreateInstance(seederType);
            modelBuilder
                .Entity(GetEntityType(seederType))
                .HasData(GetSeedData(seederType, seeder));
        }

        return modelBuilder;
    }

    private static IEnumerable<IEntity> GetSeedData(Type seederType, object seederInstance)
    {
        var seedDataMethod = seederType.GetMethod(nameof(IBaseSeeder<IEntity>.GetSeedData));
        return seedDataMethod?.Invoke(seederInstance, null) as IEnumerable<IEntity> ?? Enumerable.Empty<IEntity>();
    }

    private static Type GetEntityType(Type seederType)
    {
        var type = seederType.GetInterfaces()?
             .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseSeeder<>))?
             .GenericTypeArguments?.FirstOrDefault();
        return type;
    }

}
