using BaseSource.Core.Domain.Library.Common.Events;

namespace BaseSource.Core.Domain.Library.Entities.People.DomainEvents;

public record FirstNameChanged(int Id, string FirstName) : IDomainEvent;
