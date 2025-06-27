using BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext.Interceptors.ShadowProperties;
using BaseSource.Core.Infrastrcuture.SQL.DataContext;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext;

public abstract class BaseCommandDataContext : BaseDataContext
{
    protected BaseCommandDataContext()
    {
    }

    protected BaseCommandDataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.AddAuditableShadowProperties<long>();
        //builder.AddAuditableShadowProperties<int>();
        base.OnModelCreating(builder);
        builder.AddShadowProperty();

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
}
