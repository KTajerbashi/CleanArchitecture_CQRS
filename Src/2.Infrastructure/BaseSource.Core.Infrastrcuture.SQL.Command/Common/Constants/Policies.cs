namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.Constants;

public abstract class Policies
{
    public const string CanPurge = nameof(CanPurge);
    public const string AdminAccess = nameof(AdminAccess);
    public const string UserAccess = nameof(UserAccess);
    public static string ContentManager => nameof(ContentManager);

    public static IEnumerable<string> GetAll()
    {
        return typeof(Policies).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null)!);
    }
}
