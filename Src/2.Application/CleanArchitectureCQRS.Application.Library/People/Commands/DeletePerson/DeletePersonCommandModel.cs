using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.DeletePerson
{
    public class DeletePersonCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
