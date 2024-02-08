using FluentValidation;
using FluentValidation.AspNetCore;
using ShoppingSystem.Product.Api.Middleware;
using ShoppingSystem.Product.Application;
using ShoppingSystem.Product.Application.Usecases.Product.Queries.GetAllProducts;
using ShoppingSystem.Product.Infrastructure;
using ShppingSystem.Product.Api.Extenstions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ProductContext>(option => option.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ProductContext>(option => option.UseInMemoryDatabase(databaseName: "ProductDb"));
builder.Services
    .RegisterApplicationServices()
    .RegisterInfrastructureServices(builder.Configuration)
    ;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

app.UseLogUrl();

app.UseGlobalException();

app.Run();
