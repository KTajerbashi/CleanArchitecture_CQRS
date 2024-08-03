using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.BaseWebApi.Controllers;
using WebApi.EndPoints.Models.Identity.Authenticate;

namespace WebApi.EndPoints.Controllers.Identity;

public class AuthenticateController : BaseController
{
    public AuthenticateController(IMediator mediator) : base(mediator)
    {
    }
   
}

