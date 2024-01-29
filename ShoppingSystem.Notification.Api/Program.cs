using Prometheus;
using ShoppingSystem.Notification.Api.Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services
    .AddHealthChecks()
    .AddCheck<PrometheusHealthCheck>(nameof(PrometheusHealthCheck))
    .ForwardToPrometheus();

builder.Services.AddMetricServer(options =>
{
    options.Hostname = "https://localhost";
    options.Port = 7222;
});

//builder.Services.AddMetricServer(options => { });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapMetrics();
});

app.Run();
