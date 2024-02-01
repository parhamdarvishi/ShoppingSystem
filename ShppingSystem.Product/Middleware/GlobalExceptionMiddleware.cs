using Newtonsoft.Json;
using System.Net;

namespace ShoppingSystem.Product.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            IsSuccessful = false,
            Error = new
            {
                message = "An error occurred while processing your request.",
                details = ex.Message
            }
        };

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}

public static class GlobalException
{
    public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();

        return app;
    }
}
