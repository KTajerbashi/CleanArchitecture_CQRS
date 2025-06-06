using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Update;

public record CustomerUpdateResponse();
public class CustomerUpdateCommand : Command<CustomerUpdateResponse>
{
}

public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateCommand>
{
    public CustomerUpdateValidator()
    {

    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class CustomerUpdateHandler : CommandHandler<CustomerUpdateCommand, CustomerUpdateResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerUpdateHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CustomerUpdateResponse> Handle(CustomerUpdateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerUpdateCommand, CustomerUpdateCommand>().ReverseMap();
    }
}
