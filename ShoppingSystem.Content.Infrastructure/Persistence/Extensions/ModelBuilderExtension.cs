using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Contant.Domain.Contracts;
using ShoppingSystem.Content.Domain.Repositories;
using System.Reflection;

namespace ShoppingSystem.Content.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    /// <summary>
    /// this method gathers all classes marked by [Entity] attribute and register it to db context
    /// </summary>
    /// <param name="modelBuilder">ef core model builder</param>
    /// <param name="assemblies">assemblies to search for entity type</param>
    /// <returns>ef core model builder</returns>
    //public static ModelBuilder RegisterAllEntities(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    //{
    //    IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
    //        .Where(t =>
    //            t is { IsClass: true, IsAbstract: false, IsPublic: true } &&
    //            Attribute.IsDefined(t, typeof(EntityAttribute)));

    //    foreach (var type in types)
    //        modelBuilder.Entity(type);

    //    return modelBuilder;
    //}


    /// <summary>
    /// this method get every seeder class that implements IBaseSeeder interface
    /// get seed data from each class and add data to entity table in database
    /// </summary>
    /// <param name="modelBuilder">ef core model builder</param>
    /// <param name="assemblies">assemblies to search for seeder type</param>
    /// <returns>ef core model builder</returns>
    public static ModelBuilder RegisterAllSeeders(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var seederTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(IsValidSeederType);

        foreach (var seederType in seederTypes)
        {
            var seeder = Activator.CreateInstance(seederType);
            modelBuilder
                .Entity(GetEntityType(seederType))
                .HasData(GetSeedData(seederType, seeder));
        }
        return modelBuilder;
    }



    private static bool IsValidSeederType(Type type)
        => type is { IsClass: true, IsAbstract: false, IsPublic: true } &&
           type.GetInterfaces()
               .Any(i =>
                   i.IsGenericType &&
                   i.GetGenericTypeDefinition() == typeof(IBaseSeeder<>));


    private static IEnumerable<IEntity> GetSeedData(Type seederType, object seederInstance)
    {
        var seedDataMethod = seederType.GetMethod(nameof(IBaseSeeder<IEntity>.GetSeedData));
        return seedDataMethod?.Invoke(seederInstance, null) as IEnumerable<IEntity> ?? Enumerable.Empty<IEntity>();
    }

    private static Type GetEntityType(Type seederType)
        => seederType.GetInterfaces()
            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseSeeder<>))
            .GenericTypeArguments[0];
}
