using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.AddProductCard;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Create;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Delete;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.DeleteProductCard;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.Update;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Commands.UpdateProductCard;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Queries.GetAll;
using BaseSource.Core.Application.UseCases.Store.Card.Handlers.Queries.GetById;

namespace BaseSource.WebAPI.EndPoint.Controllers.Store;

public class CardController : AuthorizeController
{
    [HttpPost]
    public async Task<IActionResult> Create(CardCreateCommand command)
        => await CreateAsync<CardCreateCommand, CardCreateResponse>(command);

    [HttpPost("ProductCard")]
    public async Task<IActionResult> AddProductCard(AddProductCardCommand command)
        => await CreateAsync<AddProductCardCommand, AddProductCardResponse>(command);

    [HttpPut("ProductCard")]
    public async Task<IActionResult> UpdateProductCard(UpdateProductCardCommand command)
        => await UpdateAsync<UpdateProductCardCommand, UpdateProductCardResponse>(command);

    [HttpDelete("ProductCard/{entityId}")]
    public async Task<IActionResult> DeleteProductCard(Guid entityId)
        => await DeleteAsync<DeleteProductCardCommand, DeleteProductCardResponse>(new (entityId));

    [HttpPut]
    public async Task<IActionResult> Update(CardUpdateCommand command)
        => await UpdateAsync<CardUpdateCommand, CardUpdateResponse>(command);

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(Guid entityId)
        => await DeleteAsync<CardDeleteCommand, CardDeleteResponse>(new(entityId));

    [HttpGet("{entityId}")]
    public async Task<IActionResult> GetById(Guid entityId)
        => await GetAsync<CardGetByIdQuery, CardGetByIdResponse>(new(entityId));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => await GetAllAsync<CardGetAllQuery, CardGetAllResponse>(new());
}
