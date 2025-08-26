using BaseSource.Core.Domain.Aggregates.Store.Customer.Events;
using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Store.Customer;

[Table("Customers", Schema = "Store")]
public class CustomerEntity : Entity
{
    private List<CustomerAddressEntity> _addresses = new();

    private CustomerEntity() { }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    public virtual IReadOnlyCollection<CustomerAddressEntity> Addresses => _addresses.AsReadOnly();

    public static CustomerEntity Create(string firstName, string lastName, string email, string phoneNumber)
    {
        var entity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber
        };
        return entity;
    }

    public void AddAddress(string street, string city, string state, string zipCode)
    {
        var address = new CustomerAddressEntity(street, city, state, zipCode);
        _addresses.Add(address);
    }
}

