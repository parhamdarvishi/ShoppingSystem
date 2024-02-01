﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Api.Dtos;
using ShoppingSystem.Product.Application;
using ShppingSystem.Product.Api.Dtos;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;

public class ProductsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute]int id)
    {
        var product = _productService.GetById(id);
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
        _productService.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete([FromRoute] int id)
    {
        bool deleted = _productService.Delete(id);
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

        bool updated = _productService.Update(product);
        if (updated)
            return Ok();
        else
            return BadRequest();
    }
}
