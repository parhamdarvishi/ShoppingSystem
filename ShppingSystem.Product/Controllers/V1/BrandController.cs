using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Controllers.V1;

public class BrandController : BaseController
{
    private readonly ProductContext _context;
    public BrandController(ProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        List<Brand> brands = await _context.Brands.ToListAsync();
        return Ok(brands);
    }
}
