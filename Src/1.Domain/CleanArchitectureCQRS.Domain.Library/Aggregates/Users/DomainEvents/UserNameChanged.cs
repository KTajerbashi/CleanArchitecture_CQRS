using CleanArchitectureCQRS.Domain.Library.BaseDomain.Events;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;

public record UserNameChanged(int Id, string UserName) : IDomainEvent;
