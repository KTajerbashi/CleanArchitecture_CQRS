using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Customer;

[Table("CustomerAddresses", Schema = "Store")]
public class CustomerAddressEntity : Entity
{
    private CustomerAddressEntity() { }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public long CustomerId { get; private set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual CustomerEntity Customer { get; private set; }

    public CustomerAddressEntity(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}
