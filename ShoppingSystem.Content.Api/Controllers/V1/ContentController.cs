using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Content.Application.Dtos.Content;
using ShoppingSystem.Content.Application.Services;
using System.Net.Mime;

namespace ShoppingSystem.Content.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            var contents = await _contentService.GetAllContentsAsync();
            if (contents == null)
                return NotFound();

            return Ok(contents);
        }

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct = default)
        {
            var content = await _contentService.GetContentByIdAsync(id);

            if (content != null)
                return Ok(content);
            else
                return BadRequest();

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddContentDto addContentDto, CancellationToken ct = default)
        {
            var content = _mapper.Map<AddContentDto, Domain.Entities.Content>(addContentDto);
            var isCreated = await _contentService.AddContentAsync(content);

            if (isCreated)
                return Ok(isCreated);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct = default)
        {
            var isDeleted = await _contentService.DeleteContentAsync(id);

            if (isDeleted)
                return Ok(isDeleted);
            else
                return BadRequest();
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateContentDto updateProductDto, CancellationToken ct = default)
        {
            var content = _mapper.Map<UpdateContentDto, Domain.Entities.Content>(updateProductDto);
            var isProductCreated = await _contentService.UpdateContentAsync(content);
            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            return BadRequest();
        }

    }
}
