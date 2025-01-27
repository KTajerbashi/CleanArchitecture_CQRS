using BaseSource.Core.Domain.Library.BaseDomain.Events;

namespace BaseSource.Core.Domain.Library.Aggregates.People.DomainEvents;

public record FirstNameChanged(int Id, string FirstName) : IDomainEvent;
