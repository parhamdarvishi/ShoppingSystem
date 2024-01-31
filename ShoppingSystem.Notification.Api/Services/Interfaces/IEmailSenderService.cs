namespace ShoppingSystem.Notification.Api.Services.Interfaces;

public interface IEmailSenderService
{
    Task<bool> SendEmailAsync(string recipient, string message);
}
