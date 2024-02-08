using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingSystem.Product.Application.Usecases.Product;
using System.Reflection;

namespace ShoppingSystem.Product.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductProfile));
        services.AddFluentValidationAutoValidation();
      

        var assembly = typeof(ConfigureServices).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
