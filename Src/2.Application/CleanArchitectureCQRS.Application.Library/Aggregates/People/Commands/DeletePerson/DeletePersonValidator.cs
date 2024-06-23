using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;

public class DeletePersonValidator : AbstractValidator<DeletePerson>
{
    public DeletePersonValidator()
    {
        
    }
}