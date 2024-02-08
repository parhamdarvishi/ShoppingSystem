using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Application.Usecases.Product;
using System.Reflection;

namespace ShoppingSystem.Product.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}
