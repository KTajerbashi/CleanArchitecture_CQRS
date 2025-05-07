using BaseSource.Core.Application.Library.Common.RequestResponse.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Core.Application.Library.Common.Behaviors
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApplicationServiceResult, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IServiceProvider _serviceProvider;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IServiceProvider serviceProvider)
        {
            _validators = validators;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();
            TResponse res = null;
            if (validator != null)
            {
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    res = new()
                    {
                        Status = ApplicationServiceStatus.ValidationError
                    };
                    foreach (var item in validationResult.Errors)
                    {
                        res.AddMessage(item.ErrorMessage);
                    }
                }
            }
            return await next();
        }
    }
}
