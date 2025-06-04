namespace BaseSource.Utilities.CacheProvider.SQL;

public class SqlCacheOptions
{
    public bool AutoCreateTable { get; set; } = true;
    public string ConnectionString { get; set; } = string.Empty;
    public string SchemaName { get; set; } = "Cache";
    public string TableName { get; set; } = "CacheData";
}
