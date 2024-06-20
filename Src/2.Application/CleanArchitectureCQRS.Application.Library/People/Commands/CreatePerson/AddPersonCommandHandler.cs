using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.People.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.CreatePerson
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommandModel, Guid>
    {
        //private readonly ICommandApplicationContext _context;
        private readonly IApplicationContext _context;
        public AddPersonCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = new Person(
                0,
                request.Name,
                request.Family,
                request.Email,
                request.MobileNumber,
                request.NationalCode,
                request.Password);
            
             _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person.BusinessId.Value;
        }
    }
}
