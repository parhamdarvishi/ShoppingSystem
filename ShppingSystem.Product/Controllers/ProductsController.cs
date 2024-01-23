using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShppingSystem.Product.Api.Dtos;
using ShppingSystem.Product.Api.Models;

namespace ShppingSystem.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            List<Models.Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto productDto)
        {
            Models.Product product = new Models.Product()
            {
                Name = productDto.name,
                Price = productDto.price,
                Description = productDto.description,
                CreationAt = DateTime.Now,
                IsDeleted = false
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created();
        }

    }
}
