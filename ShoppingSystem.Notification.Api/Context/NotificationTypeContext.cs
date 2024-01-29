using ShoppingSystem.Notification.Api.Contracts;
using ShoppingSystem.Notification.Api.Enums;

namespace ShoppingSystem.Notification.Api.Context;

public interface INotificationTypeContext
{
    INotificationStrategy GetNotificationTypeStrategy(EnumNotificationType notificationType);
}

//[ScopedService]
public class NotificationTypeContext : INotificationTypeContext
{
    private readonly IEnumerable<INotificationStrategy> _notificationStrategies;

    public NotificationTypeContext(IEnumerable<INotificationStrategy> notificationStrategies)
    {
        _notificationStrategies = notificationStrategies;
    }

    public INotificationStrategy GetNotificationTypeStrategy(EnumNotificationType notificationType)
    {
        var notificationTypeStrategy = _notificationStrategies.FirstOrDefault(t => t.NotificationType == notificationType);
        return notificationTypeStrategy;
    }
}
