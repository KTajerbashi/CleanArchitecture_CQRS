using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Library.BaseCommandQuery.Pattern
{
    //public interface ISender
    //{
    //    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

    //    Task<object?> Send(object request, CancellationToken cancellationToken = default);
    //}

    //public interface IPublisher
    //{
    //    Task Publish(object notification, CancellationToken cancellationToken = default);

    //    Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
    //        where TNotification : INotification;
    //}

    //public interface IMediator : ISender, IPublisher
    //{
    //}
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
            => _logger = logger;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
