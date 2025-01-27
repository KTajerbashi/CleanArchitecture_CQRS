using BaseSource.Core.Domain.Library.Events;

namespace BaseSource.Core.Domain.Library.Aggregates.People.DomainEvents;

public record PersonCreated(
        Guid BusinessId,
        string FirstName,
        string LastName,
        string Email,
        string UserName,
        string Phone
        ) : IDomainEvent;
