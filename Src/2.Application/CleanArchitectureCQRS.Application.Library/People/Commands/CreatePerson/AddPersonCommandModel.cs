using MediatR;

namespace CleanArchitectureCQRS.Application.Library.People.Commands.CreatePerson
{
    public record AddPersonCommandModel(
        string Name,
        string Family, 
        string NationalCode,
        string MobileNumber,
        string Email,
        string Password,
        string RepeatPassword) : IRequest<Guid>;
}
