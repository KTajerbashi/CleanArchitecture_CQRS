using MediatR;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers.Identity;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }
}

