using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.UpdateAddress;

public record CustomerAddressUpdateResponse();
public class CustomerAddressUpdateCommand : Command<CustomerAddressUpdateResponse>
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public long CustomerId { get; set; }
}

public class CustomerAddressUpdateValidator : AbstractValidator<CustomerAddressUpdateCommand>
{
    public CustomerAddressUpdateValidator()
    {

    }
}

public class CustomerAddressUpdateHandler : CommandHandler<CustomerAddressUpdateCommand, CustomerAddressUpdateResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerAddressUpdateHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CustomerAddressUpdateResponse> Handle(CustomerAddressUpdateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerAddressProfile : Profile
{
    public CustomerAddressProfile()
    {
        CreateMap<CustomerAddressUpdateCommand, CustomerAddressUpdateCommand>().ReverseMap();
    }
}
