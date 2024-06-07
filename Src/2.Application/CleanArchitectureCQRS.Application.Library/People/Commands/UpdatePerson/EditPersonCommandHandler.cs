using CleanArchitectureCQRS.Application.Library.Databases;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.UpdatePerson;
public class EditPersonCommandHandler : IRequestHandler<EditPersonCommandModel, Guid>
{
    private readonly IApplicationContext _context;
    public EditPersonCommandHandler(IApplicationContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(EditPersonCommandModel request, CancellationToken cancellationToken)
    {
        var person = _context.People.Where(a => a.Id == request.Id).FirstOrDefault();
        if (person == null)
        {
            return default;
        }
        else
        {
            person.Name = request.Name;
            person.Family = request.Family;
            person.NationalCode = request.NationalCode;
            person.MobileNumber = request.MobileNumber;
            person.Email = request.Email;
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
