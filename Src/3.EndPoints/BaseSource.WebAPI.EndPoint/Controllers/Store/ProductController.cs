using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.AddProductDetails;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Create;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Delete;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.RemoveProductDetails;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Commands.Update;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Queries.GetAll;
using BaseSource.Core.Application.UseCases.Store.Product.Handlers.Queries.GetById;

namespace BaseSource.WebAPI.EndPoint.Controllers.Store;

public class ProductController : AuthorizeController
{
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command)
        => await CreateAsync<ProductCreateCommand, ProductCreateResponse>(command);

    [HttpPost("ProductDetails")]
    public async Task<IActionResult> AddProductDetails(AddProductDetailsCommand command)
        => await CreateAsync<AddProductDetailsCommand, AddProductDetailsResponse>(command);

    [HttpDelete("ProductDetails/{entityId}")]
    public async Task<IActionResult> RemoveProductDetails(Guid entityId)
        => await CreateAsync<RemoveProductDetailsCommand, RemoveProductDetailsResponse>(new(entityId));

    [HttpPut]
    public async Task<IActionResult> Update(ProductUpdateCommand command)
        => await UpdateAsync<ProductUpdateCommand, ProductUpdateResponse>(command);

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(Guid entityId)
        => await DeleteAsync<ProductDeleteCommand, ProductDeleteResponse>(new(entityId));

    [HttpGet("{entityId}")]
    public async Task<IActionResult> GetById(Guid entityId)
        => await GetAsync<ProductGetByIdQuery, ProductGetByIdResponse>(new(entityId));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => await GetAllAsync<ProductGetAllQuery, ProductGetAllResponse>(new());
}