using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonHandler : ICommandHandler<CreatePerson, int>
{

    public Task<int> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult<int>> Handle(CreatePerson request)
    {
        throw new NotImplementedException();
    }
}

public class CreatePerson : ICommand<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

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