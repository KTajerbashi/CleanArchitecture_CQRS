using Abstraction.Notification.Extensions;
using SendEmailService;

namespace SOAPContainerServices.Repositories.Email;

public class EmailService : IEmailRepository
{
    private readonly SendEmail_ServiceSoapClient sendEmail_ServiceSoapClient;

    public EmailService()
    {
        sendEmail_ServiceSoapClient = new SendEmail_ServiceSoapClient(SendEmail_ServiceSoapClient.EndpointConfiguration.SendEmail_ServiceSoap);
    }

    public async Task<Abstraction.Notification.Extensions.EmailResult> Recieve(int a, int b)
    {
        var serviceResult = await sendEmail_ServiceSoapClient.RecieveAsync(a,b);
        var result = serviceResult.Body.RecieveResult;
        return new Abstraction.Notification.Extensions.EmailResult
        {
            ContactNumber = result.ContactNumber,
            IsSuccess = result.IsSuccess,
        };
    }

    public async Task<Abstraction.Notification.Extensions.EmailResult> Send(Abstraction.Notification.Extensions.EmailOption option)
    {
        var serviceResult = await sendEmail_ServiceSoapClient.SendAsync(new SendEmailService.EmailOption
        {
            ContactNumber= option.ContactNumber,
            Password= option.Password,
            TextMessage= option.TextMessage,
            Username = option.Username
        });
        var result = serviceResult.Body.SendResult;
        return new Abstraction.Notification.Extensions.EmailResult
        {
            ContactNumber = result.ContactNumber,
            IsSuccess = result.IsSuccess,
        };
    }
}
