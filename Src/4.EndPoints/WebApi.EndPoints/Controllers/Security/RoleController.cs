using MediatR;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers.Security;

public class RoleController : BaseController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }
}
