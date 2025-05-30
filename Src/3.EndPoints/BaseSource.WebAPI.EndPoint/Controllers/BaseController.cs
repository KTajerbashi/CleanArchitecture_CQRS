using Microsoft.AspNetCore.Mvc;

namespace BaseSource.WebAPI.EndPoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{

}


public abstract class AuthorizeController : BaseController
{

}
