using CleanArchitectureCQRS.Application.Library.Databases;
using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword
{
    public class ChangePasswordPersonHandler : IRequestHandler<ChangePasswordCommandModel, bool>
    {
        private readonly IApplicationContext _context;

        public ChangePasswordPersonHandler(IApplicationContext context)
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
