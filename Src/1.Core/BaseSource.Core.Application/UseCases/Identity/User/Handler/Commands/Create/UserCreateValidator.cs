namespace BaseSource.Core.Application.UseCases.Identity.User.Handler.Commands.Create;

public class UserCreateValidator : AbstractValidator<UserCreateCommand>
{
    public UserCreateValidator()
    {
        RuleFor(item => item.FirstName).MinimumLength(5).WithMessage("First name must be at least 2 characters long.");
        RuleFor(item => item.LastName).MinimumLength(5).WithMessage("Last name must be at least 2 characters long.");
        RuleFor(item => item.NationalCode).Length(10).WithMessage("National code must be exactly 10 characters long.");
        RuleFor(item => item.UserName).Length(5, 20).WithMessage("Username must be between 5 and 20 characters long.");
        RuleFor(item => item.Email).EmailAddress().WithMessage("Invalid email format.");
        RuleFor(item => item.PhoneNumber).Length(10).WithMessage("Invalid phone number format.");
    }
}
