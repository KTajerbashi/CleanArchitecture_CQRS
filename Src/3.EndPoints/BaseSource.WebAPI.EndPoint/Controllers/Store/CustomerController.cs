using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.AddAddress;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Create;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Delete;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.DeleteAddress;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.Update;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Commands.UpdateAddress;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Queries.GetAll;
using BaseSource.Core.Application.UseCases.Store.Customer.Handlers.Queries.GetById;

namespace BaseSource.WebAPI.EndPoint.Controllers.Store;


public class CustomerController : AuthorizeController
{
    [HttpPost]
    public async Task<IActionResult> Create(CustomerCreateCommand command)
        => await CreateAsync<CustomerCreateCommand, CustomerCreateResponse>(command);

    [HttpPost("Address")]
    public async Task<IActionResult> Create(CustomerAddressCreateCommand command)
        => await CreateAsync<CustomerAddressCreateCommand, CustomerAddressCreateResponse>(command);

    [HttpDelete("Address/{entityId}")]
    public async Task<IActionResult> Create(CustomerAddressDeleteCommand command)
        => await CreateAsync<CustomerAddressDeleteCommand, CustomerAddressDeleteResponse>(command);

    [HttpPut("Address")]
    public async Task<IActionResult> Create(CustomerAddressUpdateCommand command)
        => await CreateAsync<CustomerAddressUpdateCommand, CustomerAddressUpdateResponse>(command);

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateCommand command)
        => await UpdateAsync<CustomerUpdateCommand, CustomerUpdateResponse>(command);

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(Guid entityId)
        => await DeleteAsync<CustomerDeleteCommand, CustomerDeleteResponse>(new(entityId));

    [HttpGet("{entityId}")]
    public async Task<IActionResult> GetById(Guid entityId)
        => await GetAsync<CustomerGetByIdQuery, CustomerGetByIdResponse>(new(entityId));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => await GetAllAsync<CustomerGetAllQuery, CustomerGetAllResponse>(new());
}
