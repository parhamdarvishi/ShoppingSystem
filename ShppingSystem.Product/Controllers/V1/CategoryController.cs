using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Product.Domain.Entities;
using ShoppingSystem.Product.Infrastructure.Contracts;
namespace ShoppingSystem.Product.Api.Controllers.V1;

public class CategoryController : BaseController
{
    private readonly IProductContext _context;
    public CategoryController(IProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        List<Category> categories = await _context.Set<Category>().ToListAsync();
        return Ok(categories);
    }
}
