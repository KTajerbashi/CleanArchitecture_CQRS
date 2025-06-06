using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

public interface ICustomerCommandRepository : ICommandRepository<CustomerEntity, long>
{
}
