using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;

namespace CleanArchitectureCQRS.Domain.Library.People.DomainEvents
{
    public record PersonSMSSend(int Id, string link) : IDomainEvent;
}
