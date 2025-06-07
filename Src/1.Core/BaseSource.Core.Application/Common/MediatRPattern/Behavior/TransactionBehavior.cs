namespace BaseSource.Core.Application.Common.MediatRPattern.Behavior;

//public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//    where TRequest : IRequest<TResponse>
//{
//    private readonly IUnitOfWork _unitOfWork;

//    public TransactionBehavior(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        if (IsNotCommand())
//        {
//            return await next();
//        }

//        var executionStrategy = _unitOfWork.GetExecutionStrategy();

//        return await executionStrategy.ExecuteAsync(async () =>
//        {
//            await _unitOfWork.BeginTransactionAsync(cancellationToken);
//            try
//            {
//                var response = await next();
//                await _unitOfWork.CommitTransactionAsync(cancellationToken);
//                return response;
//            }
//            catch
//            {
//                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
//                throw;
//            }
//        });
//    }

//    private static bool IsNotCommand()
//    {
//        return !typeof(TRequest).Name.EndsWith("Command");
//    }
//}