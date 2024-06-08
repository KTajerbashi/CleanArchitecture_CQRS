using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.DeletePerson
{
    public record DeletePersonCommandModel(Guid Id) : IRequest<Guid>;
}
