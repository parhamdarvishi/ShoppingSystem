using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Application;
using ShoppingSystem.Product.Application.Contracts;
using ShoppingSystem.Product.Infrastructure.Persistence;
using ShoppingSystem.Product.Infrastructure.Persistence.Repositories;

namespace ShoppingSystem.Product.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ProductDb"));
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}
