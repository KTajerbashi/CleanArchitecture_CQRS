namespace BaseSource.Core.Domain.Aggregates.Store.Customer.Events;

public class CustomerCreatedEvent : DomainEvent
{
    public CustomerEntity Customer { get; }

    public CustomerCreatedEvent(CustomerEntity customer)
    {
        Customer = customer;
    }
}
