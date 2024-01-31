using FluentValidation;
using FluentValidation.AspNetCore;
using ShoppingSystem.Product.Application;
using ShoppingSystem.Product.Infrastructure;
using ShppingSystem.Product.Api.Extenstions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ProductContext>(option => option.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ProductContext>(option => option.UseInMemoryDatabase(databaseName: "ProductDb"));
builder.Services
    .RegisterInfrastructureServices(builder.Configuration)
    .RegisterApplicationServices();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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

app.Run();
