using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Queries;
using BaseSource.Infra.Data.Sql.Library.Databases;

namespace BaseSource.Infra.Data.Sql.Query.Library.Patterns;


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
