using BaseSource.Core.Application.UseCases.PrintWorld.PrintCommand;
using BaseSource.Core.Application.UseCases.PrintWorld.PrintQuery;

namespace BaseSource.WebAPI.EndPoint.Controllers;

public class TestController : AuthorizeController
{
    [HttpGet("Command")]
    public async Task<IActionResult> CommandTest()
    {
        var response = await Factory.Mediator.Send(new PrintCommand("Hi"));
        return ReturnResponse(response);
    }

    [HttpGet("Query")]
    public async Task<IActionResult> QueryTest()
    {
        var response = await Factory.Mediator.Send(new PrintQuery("Hello World !"));
        return ReturnResponse(response);
    }
}
