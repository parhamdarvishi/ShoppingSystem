namespace ShoppingSystem.Notification.Api.Services.Interfaces;

public interface ISMSSenderService
{
    Task<bool> SendSMSAsync(string recipient, string message);
}
