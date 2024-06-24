using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.ChangePassword;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.UpdatePerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.WebApiBase.Controllers;

namespace WebApi.EndPoints.Controllers;




public class PersonController : BaseController
{
    public PersonController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePerson command) => await Create<CreatePerson,Guid>(command);

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


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return await Get<GetAllPerson, List<PersonQuery>>(new GetAllPerson());
    }
    
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(GetPersonById getPerson) => await Get<GetPersonById, PersonQuery>(getPerson);
    
    
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePassword command)
    {
        return Ok(await mediator.Send(command));
    }


}
