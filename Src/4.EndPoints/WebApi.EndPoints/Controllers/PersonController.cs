using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.ChangePassword;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.UpdatePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator mediator;
    public PersonController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreatePerson command) => Ok(await mediator.Send(command));

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await mediator.Send(new DeletePerson(id)));
    }
    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdatePerson command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await mediator.Send(command));
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllPerson()));
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetPersonById { PersonId = id });

        return Ok(result ?? null);
    }
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePassword command)
    {
        return Ok(await mediator.Send(command));
    }
  

}
