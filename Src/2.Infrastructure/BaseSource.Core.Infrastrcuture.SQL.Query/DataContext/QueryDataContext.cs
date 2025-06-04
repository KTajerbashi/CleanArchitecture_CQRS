using BaseSource.Core.Infrastrcuture.SQL.Query.Common.DataContext;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.DataContext;

public class QueryDataContext : BaseQueryDataContext
{
    public QueryDataContext()
    {
    }

    public QueryDataContext(DbContextOptions<QueryDataContext> options) : base(options)
    {
    }
}
