using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Repositories.CustomerAddress;

public interface ICustomerAddressCommandRepository : ICommandRepository<CustomerAddressEntity, long>
{
}
