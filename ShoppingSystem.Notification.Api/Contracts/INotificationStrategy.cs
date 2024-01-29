using ShoppingSystem.Notification.Api.Enums;

namespace ShoppingSystem.Notification.Api.Contracts;

public interface INotificationStrategy
{
    Task<bool> SendNotificationAsync(string recipient, string message);
    EnumNotificationType NotificationType { get; }
}
