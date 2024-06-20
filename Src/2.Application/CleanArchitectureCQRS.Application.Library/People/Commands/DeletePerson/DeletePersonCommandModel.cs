using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.DeletePerson
{
    public record DeletePersonCommandModel(int Id) : IRequest<Guid>;
}
