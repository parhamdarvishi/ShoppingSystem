using ShoppingSystem.Content.Api.Profile;
using ShoppingSystem.Content.Application;
using ShoppingSystem.Content.Application.Services;
using ShoppingSystem.Content.Application.Services.Implementation;
using ShoppingSystem.Content.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .RegisterApplicationServices()
    .RegisterInfrastructureServices(builder.Configuration);

builder.Services.AddScoped<IContentService, ContentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ContentProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
