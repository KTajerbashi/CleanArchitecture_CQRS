using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;

namespace CleanArchitectureCQRS.Domain.Library.People.DomainEvents
{
    public record PersonEmailSend(int Id) : IDomainEvent;
}
