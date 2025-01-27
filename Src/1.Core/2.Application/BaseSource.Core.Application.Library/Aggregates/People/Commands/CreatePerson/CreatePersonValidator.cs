namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonValidator : AbstractValidator<CreatePerson>
{
    public CreatePersonValidator()
    {
        RuleFor(c => c.FirstName)
            .NotNull().WithMessage("FirstName is Requirement")
            .MinimumLength(2).WithMessage("FirstName MinimumLength 2")
            .MaximumLength(50).WithMessage("FirstName MaximumLength 50");

        RuleFor(c => c.LastName)
            .NotNull().WithMessage("LastName is Requirement").WithErrorCode("1")
            .MinimumLength(2).WithMessage("LastName MinimumLength 2").WithErrorCode("2")
            .MaximumLength(50).WithMessage("LastName MaximumLength 50").WithErrorCode("3");
    }
}