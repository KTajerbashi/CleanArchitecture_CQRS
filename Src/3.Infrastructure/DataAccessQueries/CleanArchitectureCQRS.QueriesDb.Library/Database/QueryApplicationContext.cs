using CleanArchitectureCQRS.Application.Library.Databases;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.QueriesDb.Library.Database;

public class QueryApplicationContext : DbContext, IQueryApplicationContext
{
    public QueryApplicationContext(DbContextOptions<QueryApplicationContext> options)
        : base(options) { }

}
