using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Store.Customer;

public class CustomerQueryRepository : QueryRepository<CustomerEntity, long, QueryDataContext>, ICustomerQueryRepository
{
    public CustomerQueryRepository(QueryDataContext context) : base(context)
    {
    }
}
