using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

public interface ICustomerQueryRepository : IQueryRepository<CustomerEntity, long>
{
}
