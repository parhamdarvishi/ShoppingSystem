using Microsoft.Extensions.DependencyInjection;

namespace ShoppingSystem.Product.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
