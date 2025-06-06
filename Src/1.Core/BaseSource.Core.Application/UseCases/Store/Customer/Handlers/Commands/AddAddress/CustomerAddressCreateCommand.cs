using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.AddAddress;

public record CustomerAddressCreateResponse(long Id);
public class CustomerAddressCreateCommand : Command<CustomerAddressCreateResponse>
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public long CustomerId { get; set; }
}

public class CustomerAddressCreateValidator : AbstractValidator<CustomerAddressCreateCommand>
{
    public CustomerAddressCreateValidator()
    {

    }
}

public class CustomerAddressCreateHandler : CommandHandler<CustomerAddressCreateCommand, CustomerAddressCreateResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerAddressCreateHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<CustomerAddressCreateResponse> Handle(CustomerAddressCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            CustomerEntity entity = await _repository.GetAsync(command.CustomerId);
            entity.AddAddress(command.Street, command.City, command.State, command.ZipCode);
            await _repository.SaveChangeAsync(cancellationToken);
            return new(entity.Id);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

public class CustomerAddressProfile : Profile
{
    public CustomerAddressProfile()
    {
        CreateMap<CustomerAddressCreateCommand, CustomerAddressCreateCommand>().ReverseMap();
    }
}