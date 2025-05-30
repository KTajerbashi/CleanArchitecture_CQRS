using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BaseSource.Core.Application.Common.MediatRPattern.Behavior;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        if (_timer.ElapsedMilliseconds > 500) // threshold
        {
            _logger.LogWarning("Long Running Request: {RequestName} ({ElapsedMilliseconds} ms) {@Request}",
                typeof(TRequest).Name, _timer.ElapsedMilliseconds, request);
        }

        return response;
    }
}





