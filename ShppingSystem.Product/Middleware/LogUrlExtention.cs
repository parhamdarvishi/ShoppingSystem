namespace ShppingSystem.Product.Api.Extenstions
{
    public class LogUrlMiddleware
    {
        private readonly ILogger<LogUrlMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LogUrlMiddleware(ILogger<LogUrlMiddleware> logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await _next(context);
        }
    }

    public static class LogUrlExtention
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogUrlMiddleware>();
        }
    }
}
