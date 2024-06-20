

using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Extensions;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.ValueConversions;
using CleanArchitectureCQRS.ContextDatabase.Library.People;
using CleanArchitectureCQRS.Domain.Library.Base.Domain.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.People.Entities;
using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Globalization;
using System.Reflection.Emit;

namespace CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;

public class ApplicationContext : DbContext, IApplicationContext
{
    protected IDbContextTransaction _transaction;

    public DbSet<Person> People { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    protected ApplicationContext()
    {
    }


    public void BeginTransaction()
    {
        _transaction = Database.BeginTransaction();
    }

    public void RollbackTransaction()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Rollback();
    }

    public void CommitTransaction()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Commit();
    }

    public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
    {
        var value = Entry(entity).Property(propertyName).CurrentValue;
        return value != null
            ? (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)
            : default;
    }

    public object GetShadowPropertyValue(object entity, string propertyName)
    {
        return Entry(entity).Property(propertyName).CurrentValue;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddAuditableShadowProperties();

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();

    }

    public IEnumerable<string> GetIncludePaths(Type clrEntityType)
    {
        var entityType = Model.FindEntityType(clrEntityType);
        var includedNavigations = new HashSet<INavigation>();
        var stack = new Stack<IEnumerator<INavigation>>();
        while (true)
        {
            var entityNavigations = new List<INavigation>();
            foreach (var navigation in entityType.GetNavigations())
            {
                if (includedNavigations.Add(navigation))
                    entityNavigations.Add(navigation);
            }
            if (entityNavigations.Count == 0)
            {
                if (stack.Count > 0)
                    yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
            }
            else
            {
                foreach (var navigation in entityNavigations)
                {
                    var inverseNavigation = navigation.Inverse;
                    if (inverseNavigation != null)
                        includedNavigations.Add(inverseNavigation);
                }
                stack.Push(entityNavigations.GetEnumerator());
            }
            while (stack.Count > 0 && !stack.Peek().MoveNext())
                stack.Pop();
            if (stack.Count == 0) break;
            entityType = stack.Peek().Current.TargetEntityType;
        }
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}