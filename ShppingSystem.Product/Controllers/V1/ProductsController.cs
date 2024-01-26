using Microsoft.AspNetCore.Mvc;
using ShppingSystem.Product.Api.Businesses;
using ShppingSystem.Product.Api.Dtos;
using System.Net.Mime;

namespace ShppingSystem.Product.Api.Controllers.V1;
public class ProductsController : BaseController
{
    private readonly IProductBusiness _productBusiness;
    public ProductsController(IProductBusiness productBusiness)
    {
        _productBusiness = productBusiness;
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        List<Models.Product> products = _productBusiness.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProduct(int id)
    {
        var product = _productBusiness.GetProduct(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddProduct(AddProductDto productDto)
    {
        if (string.IsNullOrEmpty(productDto.name) || string.IsNullOrEmpty(productDto.description) || productDto.price == 0)
            return BadRequest();

        Models.Product product = new()
        {
            Name = productDto.name,
            Price = productDto.price,
            Description = productDto.description,
            CreationAt = DateTime.Now,
            IsDeleted = false
        };
        _productBusiness.AddProduct(product);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

}
