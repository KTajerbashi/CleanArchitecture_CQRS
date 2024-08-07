using Abstraction.Notification.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SOAPContainerServices.Repositories.Email;
using SOAPContainerServices.Repositories.Message;
using SOAPContainerServices.Repositories.SMS;

namespace SOAPContainerServices.Extensions.DependencyInjection;

public static class NotificationExtensions
{
    public static IServiceCollection AddNotificationService(this IServiceCollection services)
    {
        services.AddScoped<IEmailRepository, EmailService>();
        services.AddScoped<IMessageRepository, MessageService>();
        services.AddScoped<ISMSRepository, SMSService>();
        return services;
    }
}
