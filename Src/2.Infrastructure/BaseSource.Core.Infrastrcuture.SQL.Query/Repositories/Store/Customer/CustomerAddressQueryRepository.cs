using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.CustomerAddress;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Store.Customer;

public class CustomerAddressQueryRepository : QueryRepository<CustomerAddressEntity, long, QueryDataContext>, ICustomerAddressQueryRepository
{
    public CustomerAddressQueryRepository(QueryDataContext context) : base(context)
    {
    }
}


