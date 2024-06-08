using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword
{
    public record ChangePasswordCommandModel(Guid Id, string Password) : IRequest<bool>;
}
