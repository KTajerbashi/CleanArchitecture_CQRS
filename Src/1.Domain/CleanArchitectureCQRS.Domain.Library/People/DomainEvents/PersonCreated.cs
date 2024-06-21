using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;

namespace CleanArchitectureCQRS.Domain.Library.People.DomainEvents
{
    public record PersonCreated(
        int Id,
        Guid BusinessId, 
        string FirstName, 
        string LastName,
        string Email,
        string MobileNumber,
        string NationalCode,
        string Password
        ) : IDomainEvent;
}
