#nullable disable

namespace ShoppingSystem.Captcha.Api.Dtos;

public class ValidateCaptchaDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}