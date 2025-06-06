using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Customer;

public class CustomerCommandRepository : CommandRepository<CustomerEntity, long, CommandDataContext>, ICustomerCommandRepository
{
    public CustomerCommandRepository(CommandDataContext context) : base(context)
    {
    }
}
