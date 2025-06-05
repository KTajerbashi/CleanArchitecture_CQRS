namespace BaseSource.Core.Application.UseCases.Identity.User.Handler.Commands.Create;
public class UserCreateCommand : Command<UserCreateResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
