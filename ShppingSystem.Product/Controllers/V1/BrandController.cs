using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Infrastructure.Contracts;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class BrandController : BaseController
{
    private readonly IProductContext _context;
    public BrandController(IProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBrands()
    {
        var brands = _context.Set<Brand>().ToList();
        return Ok(brands);
    }

}
