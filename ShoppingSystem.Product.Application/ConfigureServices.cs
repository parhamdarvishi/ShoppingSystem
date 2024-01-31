using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Application.Implementation;

namespace ShoppingSystem.Product.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
