using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Api.Dtos;
using ShoppingSystem.Product.Application.Usecases.Product.Commands.AddProduct;
using ShoppingSystem.Product.Application.Usecases.Product.Queries.GetAllProducts;
using ShoppingSystem.Product.Application.Usecases.Product.Queries.GetProductById;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class ProductController : BaseController
{

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken ct = default)
        => await SendAsync(new GetAllProductsQuery(), ct);

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct = default)
        => await SendAsync(new GetProductByIdQuery(id), ct);

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductCommand addProductCommand, CancellationToken ct = default)
        => await SendAsync(addProductCommand, ct);

    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete([FromRoute] int id)
    {
        var item = _repository.GetById(id: id);
        if (item is null)
            return NotFound();
        bool deleted = _repository.Delete(item);
        if (deleted)
            return Ok();
        else
            return BadRequest();
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromBody] UpdateProductDto productDto)
    {
        var product = _mapper.Map<UpdateProductDto, Domain.Entities.Product>(productDto);

        bool updated = _repository.Update(product);
        if (updated)
            return Ok();
        else
            return BadRequest();
    }
}
