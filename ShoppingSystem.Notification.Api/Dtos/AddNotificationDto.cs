using ShoppingSystem.Notification.Api.Enums;

namespace ShoppingSystem.Notification.Api.Dtos;

public record AddNotificationDto(EnumNotificationType notificationType, string title, string message, string recipient);
