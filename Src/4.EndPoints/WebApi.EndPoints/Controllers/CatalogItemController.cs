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
 
}
