using MediatR;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers.Identity;

public class AuthorizationController : BaseController
{
    public AuthorizationController(IMediator mediator) : base(mediator)
    {
    }
}

