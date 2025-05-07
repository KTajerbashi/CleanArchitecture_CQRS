using BaseSource.Core.Domain.Library.Common.Events;

namespace BaseSource.Core.Domain.Library.Entities.People.DomainEvents;

public record PersonCreated(
        Guid BusinessId,
        string FirstName,
        string LastName,
        string Email,
        string UserName,
        string Phone
        ) : IDomainEvent;
