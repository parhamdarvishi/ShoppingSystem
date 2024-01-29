using ShoppingSystem.Notification.Api.Contracts;
using ShoppingSystem.Notification.Api.Enums;
using ShoppingSystem.Notification.Api.Services.Interfaces;

namespace ShoppingSystem.Notification.Api.NotificationStrategies;

public class EmailSendStrategy : INotificationStrategy
{
    public EnumNotificationType NotificationType => EnumNotificationType.EMAIL;
    private readonly IEmailSenderService _emailSenderService;

    public EmailSendStrategy(IEmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }

    public async Task<bool> SendNotificationAsync(string recipient, string message)
    {
        // Implement your email notification logic here
        var result = await _emailSenderService.SendEmailAsync(recipient, message);
        return result;
    }
}
