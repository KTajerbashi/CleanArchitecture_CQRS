using CleanArchitectureCQRS.Application.Library.Databases;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandModel, Guid>
    {
        private readonly IApplicationContext _context;
        public DeletePersonCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(DeletePersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = await _context.People.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (person == null) return default;
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
