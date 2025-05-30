using BaseSource.WebAPI.EndPoint.Common.Models.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BaseSource.WebAPI.EndPoint.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{


    protected ObjectResult ReturnResponse(object? data)
    {
        return Ok(ApiResponseFactory.Success(data, "Success"));
    }
    protected ObjectResult ReturnResponse()
    {
        return Ok(ApiResponseFactory.Success("Success"));
    }

}
