#nullable disable

namespace ShoppingSystem.Identity.Application.Models.Jwt;

public class JwtOption
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationInMinute { get; set; }
}
