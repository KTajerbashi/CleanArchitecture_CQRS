using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;

namespace CleanArchitectureCQRS.Domain.Library.People.DomainEvents
{
    public record PersonCreated(
        int Id,
        Guid BusinessId,
        string FirstName,
        string LastName,
        string Email,
        string MobileNumber,
        string NationalCode,
        string Password
        ) : IDomainEvent<Guid>
    {
        public long AggregateVersion => throw new NotImplementedException();

        public Guid AggregateId => throw new NotImplementedException();

        public DateTime TimeStamp => throw new NotImplementedException();
    }
}
