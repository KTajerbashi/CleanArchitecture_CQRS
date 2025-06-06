namespace BaseSource.WebAPI.EndPoint.Controllers.Store;

//public class CustomerAddressController : AuthorizeController
//{
//    [HttpPost]
//    public async Task<IActionResult> Create(CustomerAddressCreateCommand command)
//        => await CreateAsync<CustomerAddressCreateCommand, CustomerAddressCreateResponse>(command);

//    [HttpPut]
//    public async Task<IActionResult> Update(CustomerAddressUpdateCommand command)
//        => await UpdateAsync<CustomerAddressUpdateCommand, CustomerAddressUpdateResponse>(command);

//    [HttpDelete("{entityId}")]
//    public async Task<IActionResult> Delete(Guid entityId)
//        => await DeleteAsync<CustomerAddressDeleteCommand, CustomerAddressDeleteResponse>(new(entityId));

//    [HttpGet("{entityId}")]
//    public async Task<IActionResult> GetById(Guid entityId)
//        => await GetAsync<CustomerAddressGetByIdQuery, CustomerAddressGetByIdResponse>(new(entityId));

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//        => await GetAllAsync<CustomerAddressGetAllQuery, CustomerAddressGetAllResponse>(new());
//}