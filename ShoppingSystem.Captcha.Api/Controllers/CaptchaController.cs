using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ShoppingSystem.Captcha.Api.Controllers
{
    public class CaptchaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GenerateCaptcha()
        {
            string captcha = "dasoijasod";
            return Ok(captcha);
        }
    }
}
