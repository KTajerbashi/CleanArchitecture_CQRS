using BaseSource.Core.Application.Providers;
using BaseSource.WebAPI.EndPoint.Common.Models.ApiResponses;
using BaseSource.WebAPI.EndPoint.Extensions;

namespace BaseSource.WebAPI.EndPoint.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    protected ProviderFactory Factory => HttpContext.ApplicationContext();

    protected ObjectResult ReturnResponse(object? data)
    {
        return Ok(ApiResponseFactory.Success(data, "Success"));
    }
    protected ObjectResult ReturnResponse()
    {
        return Ok(ApiResponseFactory.Success("Success"));
    }

}
