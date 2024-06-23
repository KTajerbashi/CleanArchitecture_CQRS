using FluentValidation;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdValidator : AbstractValidator<GetPersonById>
{
    public GetPersonByIdValidator()
    {
        RuleFor(x => x.PersonId).GreaterThan(0);
    }
}