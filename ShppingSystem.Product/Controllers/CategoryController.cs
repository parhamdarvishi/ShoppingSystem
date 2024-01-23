using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductContext _context;
        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatgories()
        {
            List<Models.Category> categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }
    }
}
