using BaseSource.Core.Application.Common.MediatRPattern.Commands;
using BaseSource.Core.Application.Common.MediatRPattern.Queries;
using BaseSource.Core.Application.Providers;
using BaseSource.WebAPI.EndPoint.Common.Models.ApiResponses;
using BaseSource.WebAPI.EndPoint.Extensions;
namespace BaseSource.WebAPI.EndPoint.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    protected ProviderFactory Factory => HttpContext.ApplicationContext();

    protected virtual async Task<IActionResult> CreateAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<IActionResult> CreateAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<IActionResult> UpdateAsync<TCommand>(TCommand command)
    where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<IActionResult> UpdateAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<IActionResult> DeleteAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<IActionResult> DeleteAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<IActionResult> GetAsync<TQuery, TResponse>(TQuery query)
        where TQuery : IQuery<TResponse>
        => ReturnResponse(await Factory.Mediator.Send(query));
    protected virtual async Task<IActionResult> GetAllAsync<TQuery, TResponse>(TQuery query)
       where TQuery : IQuery<List<TResponse>>
        => ReturnResponse((await Factory.Mediator.Send(query)));


    protected virtual async Task<IActionResult> CommandAsync<TCommand>(TCommand command)
    where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<IActionResult> CommandAsync<TCommand, TResponse>(TCommand command)
    where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));

    protected virtual async Task<IActionResult> QueryAsync<TQuery, TResponse>(TQuery query)
       where TQuery : IQuery<List<TResponse>>
        => ReturnResponse((await Factory.Mediator.Send(query)));



    protected ObjectResult ReturnResponse(object? data)
        => Ok(ApiResponseFactory.Success(data, "Success"));
    protected ObjectResult ReturnResponse()
        => Ok(ApiResponseFactory.Success("Success"));

}
