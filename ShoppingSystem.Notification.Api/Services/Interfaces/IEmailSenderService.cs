namespace ShoppingSystem.Notification.Api.Services.Interfaces;

public interface IEmailSenderService
{
    Task<bool> SendSMSAsync(string recipient, string message);
}
