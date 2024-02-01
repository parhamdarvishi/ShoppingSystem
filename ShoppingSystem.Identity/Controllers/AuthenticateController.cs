using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingSystem.Identity.Application.Dtos.Authentication;
using ShoppingSystem.Identity.Application.Interfaces;
using ShoppingSystem.Identity.Domains.Entities;
using ShoppingSystem.Identity.Infrastructure.Repositories;
using ShoppingSystem.Shared.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

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
            return Ok(new Response(message: "Registered successfully!", statusCode: HttpStatusCode.OK));
        }

        
    }
}
