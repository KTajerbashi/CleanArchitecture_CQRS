using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers;

public class WebServiceController : BaseController
{
    private readonly IPersonCommandRepository personCommandRepository;
    public WebServiceController(IMediator mediator, IPersonCommandRepository personCommandRepository) : base(mediator)
    {
        this.personCommandRepository = personCommandRepository;
    }

    [HttpGet("WebServiceSoap")]
    public IActionResult WebServiceSoap()
    {
        var resultList = new List<string>();
        var result = Task.FromResult(personCommandRepository.SendEmail());
        for (int i = 1; i < 100000; i++)
        {
            if (result.IsCompletedSuccessfully)
            {
                resultList.Add($"{i} => ✔ Successfully Done ...");
            }
            else
            {
                resultList.Add($"{i} => ❌ Disconnected WebService ... ");
            }
        }
        return Ok(resultList);
    }
}

