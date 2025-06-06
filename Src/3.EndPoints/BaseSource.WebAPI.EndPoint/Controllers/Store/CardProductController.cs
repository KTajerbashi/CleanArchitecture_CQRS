namespace BaseSource.WebAPI.EndPoint.Controllers.Store;

//public class CardProductController : AuthorizeController
//{
//    [HttpPost]
//    public async Task<IActionResult> Create(CardProductCreateCommand command)
//        => await CreateAsync<CardProductCreateCommand, CardProductCreateResponse>(command);

//    [HttpPut]
//    public async Task<IActionResult> Update(CardProductUpdateCommand command)
//        => await UpdateAsync<CardProductUpdateCommand, CardProductUpdateResponse>(command);

//    [HttpDelete("{entityId}")]
//    public async Task<IActionResult> Delete(Guid entityId)
//        => await DeleteAsync<CardProductDeleteCommand, CardProductDeleteResponse>(new(entityId));

//    [HttpGet("{entityId}")]
//    public async Task<IActionResult> GetById(Guid entityId)
//        => await GetAsync<CardProductGetByIdQuery, CardProductGetByIdResponse>(new(entityId));

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//        => await GetAllAsync<CardProductGetAllQuery, CardProductGetAllResponse>(new());
//}