using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Application.Contracts;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class BrandController : BaseController
{
    private readonly IBrandService _service;
    public BrandController(IBrandService service) =>  _service = service;

    [HttpGet]
    public IActionResult GetBrands()
    {
        return Ok();
    }

}
