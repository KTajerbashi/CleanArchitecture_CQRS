using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword
{
    public record ChangePasswordCommandModel(int Id, string Password) : IRequest<bool>;
}
