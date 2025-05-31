namespace BaseSource.Utilities.Models;

public class PagedData<T> : IQueryModel
    where T : QueryModel
{
    public List<T> QueryResult { get; set; }
    public int PageNumber { get; set; } = 1;
    public int Take { get; set; } = 10;
    public int TotalCount { get; set; }
}

