using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Identity.Application.Dtos.Authentication;
using ShoppingSystem.Identity.Application.Interfaces;

namespace ShoppingSystem.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthenticateController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = _jwtService.GenerateJwtTokenAsync(dto);
            if (result is null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var responseDto = await _userService.RegisterAsync(dto);
            if (responseDto is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        
    }
}
