using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace BaseSource.Core.Application.Library.BaseApplication.Behaviors
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            string? userName = string.Empty;


            _logger.LogInformation("CleanArchitecture Request: {Name} {@UserName} {@Request}", requestName, userName, request);
        }
    }
}
