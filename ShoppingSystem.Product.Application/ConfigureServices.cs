using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Application.Contracts;
using System.Reflection;

namespace ShoppingSystem.Product.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        Assembly currentAssem = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(currentAssem));
        return services;
    }
}
