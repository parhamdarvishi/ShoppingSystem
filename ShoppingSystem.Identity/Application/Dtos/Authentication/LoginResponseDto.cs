#nullable disable

namespace ShoppingSystem.Identity.Application.Dtos.Authentication;

public record LoginResponseDto
{
    public string Username { get; set; }
    public string Token { get; set; }
    public int ExpireInMinute { get; set; }
}
