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

    protected virtual async Task<ObjectResult> CreateAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<ObjectResult> CreateAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<ObjectResult> UpdateAsync<TCommand>(TCommand command)
    where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<ObjectResult> UpdateAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<ObjectResult> DeleteAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<ObjectResult> DeleteAsync<TCommand, TResponse>(TCommand command)
       where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));


    protected virtual async Task<ObjectResult> GetAsync<TQuery, TResponse>(TQuery query)
        where TQuery : IQuery<TResponse>
        => ReturnResponse(await Factory.Mediator.Send(query));
    protected virtual async Task<ObjectResult> GetAllAsync<TQuery, TResponse>(TQuery query)
       where TQuery : IQuery<List<TResponse>>
        => ReturnResponse((await Factory.Mediator.Send(query)));


    protected virtual async Task<ObjectResult> CommandAsync<TCommand>(TCommand command)
    where TCommand : ICommand
    {
        await Factory.Mediator.Send(command);
        return ReturnResponse();
    }
    protected virtual async Task<ObjectResult> CommandAsync<TCommand, TResponse>(TCommand command)
    where TCommand : ICommand<TResponse>
        => ReturnResponse((await Factory.Mediator.Send(command)));

    protected virtual async Task<ObjectResult> QueryAsync<TQuery, TResponse>(TQuery query)
       where TQuery : IQuery<List<TResponse>>
        => ReturnResponse((await Factory.Mediator.Send(query)));



    protected ObjectResult ReturnResponse(object? data)
        => Ok(ApiResponseFactory.Success(data, "Success"));
    protected ObjectResult ReturnResponse()
        => Ok(ApiResponseFactory.Success("Success"));

}
