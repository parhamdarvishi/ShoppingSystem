using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Controllers.V1;

public class CategoryController : BaseController
{
    private readonly ProductContext _context;
    public CategoryController(ProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCatgories()
    {
        List<Category> categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }
}
