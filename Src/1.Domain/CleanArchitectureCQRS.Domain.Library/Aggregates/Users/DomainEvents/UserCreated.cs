using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;

public record UserCreated(
        Guid BusinessId,
        string FirstName,
        string LastName,
        string Email,
        string UserName,
        string Phone
        ) : IDomainEvent;
