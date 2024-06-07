using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Domain.Library.Person.Entities;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.CreatePerson
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommandModel, Guid>
    {
        private readonly ICommandApplicationContext _context;
        public AddPersonCommandHandler(ICommandApplicationContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Family = request.Family,
                MobileNumber = request.MobileNumber,
                NationalCode = request.NationalCode,
                Password = request.Password
            };
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
