namespace BaseSource.Core.Infrastrcuture.SQL.DataContext;

public abstract class BaseDataContext : IdentityDbContext<UserIdentity, RoleIdentity, long, UserClaimIdentity, UserRoleIdentity, UserLoginIdentity, RoleClaimIdentity, UserTokenIdentity>
{
    protected BaseDataContext()
    {

    }

    protected BaseDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyIdentityConfiguration();
    }

    public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
    {
        var value = Entry(entity).Property(propertyName).CurrentValue;
        var condition = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)!;
        return value != null ? condition : default!;
    }
    public object GetShadowPropertyValue(object entity, string propertyName) => Entry(entity).Property(propertyName).CurrentValue!;

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
