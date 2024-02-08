using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Content.Domain.Repositories;
using ShoppingSystem.Content.Infrastructure.Persistence;
using ShoppingSystem.Content.Infrastructure.Persistence.Repositories;

namespace ShoppingSystem.Content.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ContentDb"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IContentRepository, ContentRepository>();

        return services;
    }
}
