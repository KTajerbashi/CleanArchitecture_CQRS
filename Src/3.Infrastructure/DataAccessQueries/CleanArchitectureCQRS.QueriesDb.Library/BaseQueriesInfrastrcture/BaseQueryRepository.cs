using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;

namespace CleanArchitectureCQRS.QueriesDb.Library.BaseQueriesInfrastrcture;


/// <summary>
/// پایه سرویس خواندن
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
