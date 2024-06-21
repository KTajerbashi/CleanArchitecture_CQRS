using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Create;
using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Deleted;
using CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Update;
using CleanArchitectureCQRS.Application.Library.Catalogs.Queries.GetCatalogItemLogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogItemController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateCatalogItemAsync([FromBody] CreateCatalogItemDTO? dto)
    {
        if (dto == null)
            return BadRequest();

        var command = new CreateCatalogItemCommand(dto.Name, dto.Description, dto.Price, dto.AvailableStock, dto.RestockThreshold,
                dto.MaxStockThreshold, dto.OnReorder);
        await _mediator.Publish(command);

        return Ok(command);
    }

    [HttpPatch("update/{id:guid}")]
    public async Task<IActionResult> UpdateCatalogItem(Guid id, [FromBody] UpdateCatalogItemDTO? dto)
    {
        if (dto == null)
            return BadRequest();

        var updateCommand = new UpdateCatalogItemCommand(id, dto.Name, dto.Description, dto.Price, dto.AvailableStock,
                dto.RestockThreshold, dto.MaxStockThreshold, dto.OnReorder);
        await _mediator.Publish(updateCommand);

        return Ok(updateCommand);
    }
    /// <summary>
    /// Delete a catalog item which is soft delete not hard delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteCatalogItem(Guid id)
    {
        var deleteCatalogCommand = new DeleteCatalogItemCommand(id);
        await _mediator.Publish(deleteCatalogCommand);
        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("log/{id:guid}")]
    public async Task<IActionResult> GetLog(Guid id)
    {
        return Ok(await _mediator.Send(new GetCatalogItemLogByIdQuery(id)));
    }
}
