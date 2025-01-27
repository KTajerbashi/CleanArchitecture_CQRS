using BaseSource.Core.Domain.Library.Events;

namespace BaseSource.Core.Domain.Library.Aggregates.People.DomainEvents;

public record UserNameChanged(int Id, string UserName) : IDomainEvent;
