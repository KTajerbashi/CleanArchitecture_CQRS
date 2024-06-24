using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePassword>
{
    public ChangePasswordValidator()
    {
        RuleFor(item => item.Id).GreaterThan(0).WithMessage("Id is Required");
        RuleFor(item => item.Password)
            .MinimumLength(6).WithMessage("Password Minimum is 6 Charecter")
            .MaximumLength(12).WithMessage("Password Maximum is 12 Charecter");
    }
}