using Microsoft.AspNetCore.Identity;
using ShoppingSystem.Identity.Application.Dtos.Authentication;
using ShoppingSystem.Identity.Application.Interfaces;
using ShoppingSystem.Identity.Domains.Entities;
using System.Net;

namespace ShoppingSystem.Identity.Infrastructure.Repositories;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    public readonly IJwtService _jwtService;
    public UserService(UserManager<User> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<RegisterResponseDto> RegisterAsync(RegisterDto dto)
    {
        var userExists = await _userManager.FindByNameAsync(dto.Username);

        if (userExists != null)
            return null;

        User user = new()
        {
            NationalCode = dto.NationalCode,
            Email = dto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = dto.Username
        };
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return null;

        return new RegisterResponseDto()
        {
            Username = dto.Username
        };
    }
}
