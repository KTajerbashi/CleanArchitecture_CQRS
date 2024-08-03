using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Commands.CreateUser;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetAllUser;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.EndPoints.BaseWebApi.Controllers;

namespace WebApi.EndPoints.Controllers.Security;

public class UserController : BaseController
{
    private readonly ILogger<UserController> _logger;
    private readonly Stopwatch _stopwatch;
    public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator)
    {
        _logger = logger;
        _stopwatch = new Stopwatch();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUser command)
    {
        _stopwatch.Start();
        _logger.LogInformation($"=>Start Stopwatch{_stopwatch.ElapsedMilliseconds}");

        for (int i = 1; i <= 1000; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            _logger.LogInformation($"=> Start Handler{i} : Stopwatch{_stopwatch.ElapsedMilliseconds}");
            await Create<CreateUser, Guid>(command);
            _logger.LogInformation($"=> Start Handler{i} : Stopwatch{_stopwatch.ElapsedMilliseconds}");
        }
        _stopwatch.Stop();
        _logger.LogInformation($"=>Stop Stopwatch{_stopwatch.ElapsedMilliseconds}");
        return Ok();
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return await Get<GetAllUsers, List<UserModel>>(new GetAllUsers());
    }
}
