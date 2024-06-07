using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword
{
    public class ChangePasswordCommandModel : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        // Additional properties here
    }
}
