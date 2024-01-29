using ShoppingSystem.Notification.Api.Services.Interfaces;

namespace ShoppingSystem.Notification.Api.Services.Implementation;

public class SMSSenderService : ISMSSenderService
{
    public async Task<bool> SendSMSAsync(string recipient, string message)
    {
        return true;
    }
}
