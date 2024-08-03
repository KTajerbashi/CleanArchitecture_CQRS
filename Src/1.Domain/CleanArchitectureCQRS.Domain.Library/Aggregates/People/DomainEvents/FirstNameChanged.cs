using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;

public record FirstNameChanged(int Id, string FirstName) : IDomainEvent;
