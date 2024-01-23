using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Controllers
{
    public class BrandController : Controller
    {
        private readonly ProductContext _context;
        public BrandController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            List<Models.Brand> brands = await _context.Brands.ToListAsync();
            return Ok(brands);
        }
    }
}
