using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Commands.CreateUser;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetAllUser;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.WebApiBase.Controllers;

namespace WebApi.EndPoints.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUser command) => await Create<CreateUser, Guid>(command);


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return await Get<GetAllUsers, List<UserModel>>(new GetAllUsers());
    }
}
