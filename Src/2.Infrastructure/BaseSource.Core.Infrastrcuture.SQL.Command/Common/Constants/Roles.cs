namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.Constants;

public static class Roles
{
    public static string Administrator => nameof(Administrator);
    public static string User => nameof(User);
    public static string ContentManager => nameof(ContentManager);

    public static IEnumerable<string> GetAll()
    {
        return typeof(Roles).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null)!);
    }
}
