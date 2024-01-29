using ShoppingSystem.Notification.Api.Contracts;
using ShoppingSystem.Notification.Api.Enums;
using ShoppingSystem.Notification.Api.Services.Interfaces;

namespace ShoppingSystem.Notification.Api.NotificationStrategies;

public class SMSSendStrategy : INotificationStrategy
{
    public EnumNotificationType NotificationType => EnumNotificationType.SMS;
    private readonly ISMSSenderService _smsSenderService;

    public SMSSendStrategy(ISMSSenderService smsSenderService)
    {
        _smsSenderService = smsSenderService;
    }

    public async Task<bool> SendNotificationAsync(string recipient, string message)
    {
        // Implement your SMS notification logic here
        var result = await _smsSenderService.SendSMSAsync(recipient, message);
        return result;
    }
}
