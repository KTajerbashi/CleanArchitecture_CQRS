using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePassword>
{
    public ChangePasswordValidator()
    {
        
    }
}