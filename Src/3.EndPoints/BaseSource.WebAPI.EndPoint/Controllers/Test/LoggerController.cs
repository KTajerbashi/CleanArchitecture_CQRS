using BaseSource.Core.Application.UseCases.PrintWorld.PrintCommand;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;

public class LoggerModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime RequestDate { get; set; }
}
public class LoggerController : AuthorizeController
{
    private readonly ILogger<LoggerController> _logger;

    public LoggerController(ILogger<LoggerController> logger)
    {
        _logger = logger;
    }

    [HttpPost("Log")]
    public async Task<IActionResult> Log(LoggerModel parameter)
    {
        _logger.Log(LogLevel.Information,string.Format("Log : {0}", Factory.Json.Serialize(parameter)));
        return ReturnResponse(parameter);
    }
}
