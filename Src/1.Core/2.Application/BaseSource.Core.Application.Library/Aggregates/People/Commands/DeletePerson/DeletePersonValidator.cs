namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.DeletePerson;

public class DeletePersonValidator : AbstractValidator<DeletePerson>
{
    public DeletePersonValidator()
    {
        RuleFor(x => x.id).GreaterThan(0).WithMessage("Id is not required");
    }

}