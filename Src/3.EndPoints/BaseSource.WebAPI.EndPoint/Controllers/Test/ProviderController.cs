using BaseSource.Core.Application.UseCases.PrintWorld.PrintCommand;
using BaseSource.Core.Application.UseCases.PrintWorld.PrintedEvent;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;

public class ProviderController : AuthorizeController
{

    /// <summary>
    /// ✅
    /// ✔
    /// </summary>
    /// <returns></returns>

    [HttpGet("MediatR")]
    public async Task<IActionResult> MediatR()
    {
        var response = await Factory.Mediator.Send(new PrintCommand("Hello Dear"));
        return ReturnResponse(response);
    }


    [HttpGet("Publisher")]
    public async Task<IActionResult> Publisher()
    {
        await Factory.Publisher.Publish(new PrintedEvent("Hello Publisher"), CancellationToken.None);
        return ReturnResponse();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <returns></returns>
    [HttpGet("NotificationPublisher")]
    public async Task<IActionResult> NotificationPublisher()
    {
        await Task.CompletedTask;
        return ReturnResponse();
    }


    [HttpGet("Query")]
    public async Task<IActionResult> Query()
    {
        await Task.CompletedTask;
        return ReturnResponse();
    }


    [HttpGet("Cache")]
    public async Task<IActionResult> Cache()
    {
        await Task.CompletedTask;
        return ReturnResponse();
    }



    [HttpGet("Json")]
    public async Task<IActionResult> Json()
    {
        await Task.CompletedTask;
        return ReturnResponse();
    }



    [HttpGet("Mapper")]
    public async Task<IActionResult> Mapper()
    {
        await Task.CompletedTask;
        return ReturnResponse();
    }

    [HttpGet("LoggerFactory")]
    public async Task<IActionResult> LoggerFactory()
    {
        ILogger _looger = Factory.LoggerFactory.CreateLogger("Factory");
        _looger.LogTrace($"LogTrace : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        _looger.LogDebug($"LogDebug : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        _looger.LogInformation($"LogInformation : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        _looger.LogWarning($"LogWarning : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        _looger.LogError($"LogError : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        _looger.LogCritical($"LogCritical : Hello : LoggerFactory {DateTime.Now.ToString("G")}");
        return ReturnResponse();
    }
}
