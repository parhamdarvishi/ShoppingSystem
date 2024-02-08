using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingSystem.Content.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        return services;
    }
}
