using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Api.Dtos;
using ShoppingSystem.Product.Application.Contracts;
using ShppingSystem.Product.Api.Dtos;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class ProductController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    public ProductController(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var products = _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductDto productDto)
    {
        if (string.IsNullOrEmpty(productDto.name) || string.IsNullOrEmpty(productDto.description) || productDto.price == 0)
            return BadRequest();

        var product = _mapper.Map<AddProductDto, Domain.Entities.Product>(productDto);
        await _repository.AddAsync(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var item = await _repository.GetByIdAsync(id: id);
        if (item is null)
            return NotFound();
        bool deleted = await _repository.DeleteAsync(item);
        if (deleted)
            return Ok();
        else
            return BadRequest();
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto productDto)
    {
        var product = _mapper.Map<UpdateProductDto, Domain.Entities.Product>(productDto);

        bool updated = await _repository.UpdateAsync(product);
        if (updated)
            return Ok();
        else
            return BadRequest();
    }
}
