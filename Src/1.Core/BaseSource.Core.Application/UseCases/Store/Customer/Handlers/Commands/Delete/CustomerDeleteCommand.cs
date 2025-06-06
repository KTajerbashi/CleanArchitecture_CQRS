using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Delete;

public record CustomerDeleteResponse();
public class CustomerDeleteCommand : Command<CustomerDeleteResponse>
{
    public CustomerDeleteCommand(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}

public class CustomerDeleteValidator : AbstractValidator<CustomerDeleteCommand>
{
    public CustomerDeleteValidator()
    {

    }
}

public class CustomerDeleteHandler : CommandHandler<CustomerDeleteCommand, CustomerDeleteResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerDeleteHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override Task<CustomerDeleteResponse> Handle(CustomerDeleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDeleteCommand, CustomerDeleteCommand>().ReverseMap();
    }
}