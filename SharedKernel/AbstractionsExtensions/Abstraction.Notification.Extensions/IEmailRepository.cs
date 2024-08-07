namespace Abstraction.Notification.Extensions;

public interface IEmailRepository
{
    Task<EmailResult> Recieve(int a, int b);
    Task<EmailResult> Send(EmailOption option);
}
public class EmailOption
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string TextMessage { get; set; }
    public string ContactNumber { get; set; }
}

public class EmailResult
{
    public string ContactNumber { get; set; }
    public bool IsSuccess { get; set; }
}