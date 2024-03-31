using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Application.Contracts;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class BrandController : BaseController
{
    private readonly IBrandRepository _repository;
    public BrandController(IBrandRepository repository) => _repository = repository;

    [Route("{id}")]
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] int id)
    {
        //var item = _repository.GetByIdAsync(id);
        //return Ok(item);
        return Ok();
    }

}
