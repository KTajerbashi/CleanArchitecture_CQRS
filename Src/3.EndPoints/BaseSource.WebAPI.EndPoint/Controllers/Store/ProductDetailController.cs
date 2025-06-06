namespace BaseSource.WebAPI.EndPoint.Controllers.Store;

//public class ProductDetailController : AuthorizeController
//{
//    [HttpPost]
//    public async Task<IActionResult> Create(ProductDetailCreateCommand command)
//        => await CreateAsync<ProductDetailCreateCommand, ProductDetailCreateResponse>(command);

//    [HttpPut]
//    public async Task<IActionResult> Update(ProductDetailUpdateCommand command)
//        => await UpdateAsync<ProductDetailUpdateCommand, ProductDetailUpdateResponse>(command);

//    [HttpDelete("{entityId}")]
//    public async Task<IActionResult> Delete(Guid entityId)
//        => await DeleteAsync<ProductDetailDeleteCommand, ProductDetailDeleteResponse>(new(entityId));

//    [HttpGet("{entityId}")]
//    public async Task<IActionResult> GetById(Guid entityId)
//        => await GetAsync<ProductDetailGetByIdQuery, ProductDetailGetByIdResponse>(new(entityId));

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//        => await GetAllAsync<ProductDetailGetAllQuery, ProductDetailGetAllResponse>(new());
//}