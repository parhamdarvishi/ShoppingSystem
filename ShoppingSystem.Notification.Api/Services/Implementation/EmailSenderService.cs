﻿using ShoppingSystem.Notification.Api.Services.Interfaces;

namespace ShoppingSystem.Notification.Api.Services.Implementation;

public class EmailSenderService : IEmailSenderService
{
    public Task<bool> SendEmailAsync(string recipient, string message)
    {
        throw new NotImplementedException();
    }

}
