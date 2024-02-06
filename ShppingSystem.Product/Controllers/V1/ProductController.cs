using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Api.Dtos;
using ShoppingSystem.Product.Application.Contracts;
using ShppingSystem.Product.Api.Dtos;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class ProductController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    public ProductController(IProductRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var products = _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute]int id)
    {
        var product = _repository.GetById(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Add([FromBody] AddProductDto productDto)
    {
        if (string.IsNullOrEmpty(productDto.name) || string.IsNullOrEmpty(productDto.description) || productDto.price == 0)
            return BadRequest();

        var product = _mapper.Map<AddProductDto, Domain.Entities.Product>(productDto);
        _repository.Add(product);
        
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

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
