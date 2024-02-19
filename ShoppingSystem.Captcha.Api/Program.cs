using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Captcha.Api.Context;
using ShoppingSystem.Captcha.Api.Dtos;
using ShoppingSystem.Captcha.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("CaptchaService"));

// Add services to the container.

var app = builder.Build();

app.MapPost("/GenerateImage", async (AddCaptchaDto dto, ApplicationDbContext dbContext) =>
{
    
    Captcha captcha = new Captcha()
    {
        CreateAt = DateTime.Now,
        ValidUntil = DateTime.Now.AddMinutes(2),
        Key = dto.Key,
    };
    captcha.GenerateValue();

    dbContext.Captchas.Add(captcha);
    await dbContext.SaveChangesAsync();

    return Results.Created();
});

app.MapPost("/Validate", async (AddCaptchaDto dto, ApplicationDbContext dbContext) =>
{
    Captcha captcha = new Captcha()
    {
        CreateAt = DateTime.Now,
        ValidUntil = DateTime.Now.AddMinutes(2),
        Key = dto.Key,
    };
    captcha.GenerateValue();

    dbContext.Captchas.Add(captcha);
    await dbContext.SaveChangesAsync();

    return Results.Created();
});

app.Run();
