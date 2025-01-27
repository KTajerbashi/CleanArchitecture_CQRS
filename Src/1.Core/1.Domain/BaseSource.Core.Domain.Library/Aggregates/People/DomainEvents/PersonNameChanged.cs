using BaseSource.Core.Domain.Library.Events;

namespace BaseSource.Core.Domain.Library.Aggregates.People.DomainEvents;

public record PersonNameChanged(int Id, string FirstName) : IDomainEvent;
