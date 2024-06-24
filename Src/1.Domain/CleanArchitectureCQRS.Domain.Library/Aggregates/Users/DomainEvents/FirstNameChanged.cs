using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;

public record FirstNameChanged(int Id, string FirstName) : IDomainEvent;
