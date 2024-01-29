using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Notification.Api.Context;
using ShoppingSystem.Notification.Api.Dtos;

namespace ShoppingSystem.Notification.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class NotificationController : Controller
{
    private readonly INotificationTypeContext _notificationTypeContext;
    public NotificationController(INotificationTypeContext notificationTypeContext)
    {
        _notificationTypeContext = notificationTypeContext;
    }

    [Route("")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddNotificationDto notificationDto)
    {

        var smsStrategy = _notificationTypeContext.GetNotificationTypeStrategy(notificationDto.notificationType);
        bool smsSent = await smsStrategy.SendNotificationAsync(notificationDto.recipient, notificationDto.message);
        return Ok(smsSent);
    }

    [Route("")]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("askjdnkj");
    }
}
