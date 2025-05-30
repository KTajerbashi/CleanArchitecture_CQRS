﻿using Microsoft.Extensions.Logging;

namespace BaseSource.Core.Application.Common.MediatRPattern.Behavior;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation("Handling {RequestName} with content: {@Request}", requestName, request);

        var response = await next();

        _logger.LogInformation("Handled {RequestName} with response: {@Response}", requestName, response);
        return response;
    }
}


