using BaseSource.Core.Application.UseCases.Store.Customer.Repositories.Customer;
using BaseSource.Core.Domain.Aggregates.Store.Customer;

namespace BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Create;

public record CustomerCreateResponse(long Id);
public class CustomerCreateCommand : Command<CustomerCreateResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class CustomerCreateValidator : AbstractValidator<CustomerCreateCommand>
{
    public CustomerCreateValidator()
    {

    }
}

public class CustomerCreateHandler : CommandHandler<CustomerCreateCommand, CustomerCreateResponse>
{
    private readonly ICustomerCommandRepository _repository;
    public CustomerCreateHandler(ProviderFactory factory, ICustomerCommandRepository repository) : base(factory)
    {
        _repository = repository;
    }

    public override async Task<CustomerCreateResponse> Handle(CustomerCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            CustomerEntity entity = CustomerEntity.Create(command.FirstName,command.LastName,command.Email,command.PhoneNumber);
            var id = await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return new(id);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerCreateCommand, CustomerCreateCommand>().ReverseMap();
    }
}