using ShoppingSystem.Identity.Application.Dtos.Authentication;
using ShoppingSystem.Identity.Infrastructure.Repositories;

namespace ShoppingSystem.Identity.Application.Interfaces;

public interface IUserService
{
    Task<LoginResponseDto> LoginAsync(LoginDto dto);
    Task<RegisterResponseDto> RegisterAsync(RegisterDto dto);
}
