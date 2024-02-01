#nullable disable

namespace ShoppingSystem.Identity.Application.Dtos.Authentication;

public record RegisterDto
{
    public string NationalCode { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
