using ShoppingSystem.Identity.Application.Dtos.Authentication;

namespace ShoppingSystem.Identity.Application.Interfaces;

public interface IJwtService
{
    Task<LoginResponseDto> GenerateJwtTokenAsync(LoginDto loginDto);
}
