using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Infrastructure.Contracts;
using ShoppingSystem.Product.Infrastructure.Persistence;

namespace ShoppingSystem.Product.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IProductContext, ProductContext>((options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ProductDb"));
        });

        return services;
    }
}
