using CleanArchitectureCQRS.Application.Library.Databases;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword
{
    public class ChangePasswordPersonHandler : IRequestHandler<ChangePasswordCommandModel, bool>
    {
        private readonly ICommandApplicationContext _context;

        public ChangePasswordPersonHandler(ICommandApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ChangePasswordCommandModel request, CancellationToken cancellationToken)
        {
            var person = _context.People.FirstOrDefault(model => model.Id == request.Id);
            if (person == null)
            {
                return await Task.FromResult(false);
            }
            person.Password = request.Password;
            _context.People.Update(person);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
