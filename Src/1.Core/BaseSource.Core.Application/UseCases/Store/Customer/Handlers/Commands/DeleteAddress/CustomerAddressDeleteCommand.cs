using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.DeleteAddress;

public record CustomerAddressDeleteResponse();
public class CustomerAddressDeleteCommand : Command<CustomerAddressDeleteResponse>
{
    public CustomerAddressDeleteCommand(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}

public class CustomerAddressDeleteValidator : AbstractValidator<CustomerAddressDeleteCommand>
{
    public CustomerAddressDeleteValidator()
    {

    }
}

public class CustomerAddressDeleteHandler : CommandHandler<CustomerAddressDeleteCommand, CustomerAddressDeleteResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerAddressDeleteHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CustomerAddressDeleteResponse> Handle(CustomerAddressDeleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerAddressProfile : Profile
{
    public CustomerAddressProfile()
    {
        CreateMap<CustomerAddressDeleteCommand, CustomerAddressDeleteCommand>().ReverseMap();
    }
}