namespace BaseSource.Utilities.Models;

public class ResultQuery<TModel> : IQueryModel
{
    public IEnumerable<TModel> Data { get; set; }
    public int Count { get; set; }
    public bool ExistData { get; set; }
}

