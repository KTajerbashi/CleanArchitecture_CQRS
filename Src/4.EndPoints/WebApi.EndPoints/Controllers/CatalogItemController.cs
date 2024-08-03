using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogItemController : BaseController
{
    public CatalogItemController(IMediator mediator) : base(mediator)
    {
    }
}
