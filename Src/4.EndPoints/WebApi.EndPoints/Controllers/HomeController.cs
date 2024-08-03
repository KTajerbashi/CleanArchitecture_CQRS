using MediatR;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers;

public class HomeController : BaseController
{
    public HomeController(IMediator mediator) : base(mediator)
    {
    }
}
