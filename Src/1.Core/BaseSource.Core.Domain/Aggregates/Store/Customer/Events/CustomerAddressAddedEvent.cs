namespace BaseSource.Core.Domain.Aggregates.Store.Customer.Events;

public class CustomerAddressAddedEvent : DomainEvent
{
    public long CustomerId { get; }
    public CustomerAddressEntity Address { get; }

    public CustomerAddressAddedEvent(long customerId, CustomerAddressEntity address)
    {
        CustomerId = customerId;
        Address = address;
    }
}
