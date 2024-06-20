using CleanArchitectureCQRS.Application.Library.People.Commands.ChangePassword;
using CleanArchitectureCQRS.Application.Library.People.Commands.CreatePerson;
using CleanArchitectureCQRS.Application.Library.People.Commands.DeletePerson;
using CleanArchitectureCQRS.Application.Library.People.Commands.UpdatePerson;
using CleanArchitectureCQRS.Application.Library.People.Queries;
using CleanArchitectureCQRS.Application.Library.People.Queries.GetAllPerson;
using CleanArchitectureCQRS.Application.Library.People.Queries.GetPersonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.EndPoints.Controllers
{
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
        public async Task<IActionResult> Create(AddPersonCommandModel command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllPersonQueryModel()));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetPersonByIdQueryModel { Id = id });

            return Ok(result ?? null);
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommandModel command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeletePersonCommandModel(id)));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, EditPersonCommandModel command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }
    }
}
