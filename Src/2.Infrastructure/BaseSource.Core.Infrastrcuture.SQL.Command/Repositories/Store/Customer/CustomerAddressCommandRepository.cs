using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.CustomerAddress;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Store.Customer;

public class CustomerAddressCommandRepository : CommandRepository<CustomerAddressEntity, long, CommandDataContext>, ICustomerAddressCommandRepository
{
    public CustomerAddressCommandRepository(CommandDataContext context) : base(context)
    {
    }
}
