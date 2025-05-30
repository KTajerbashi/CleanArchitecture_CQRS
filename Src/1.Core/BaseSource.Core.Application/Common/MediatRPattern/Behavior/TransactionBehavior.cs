namespace BaseSource.Core.Application.Common.MediatRPattern.Behavior;

//public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : IRequest<TResponse>
//{
//    private readonly DbContext _dbContext;

//    public TransactionBehavior(DbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        var strategy = _dbContext.Database.CreateExecutionStrategy();

//        return await strategy.ExecuteAsync(async () =>
//        {
//            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
//            var response = await next();
//            await _dbContext.SaveChangesAsync(cancellationToken);
//            await transaction.CommitAsync(cancellationToken);
//            return response;
//        });
//    }
//}
