namespace BaseSource.Utilities.Models;

public interface IQueryModel
{
}
public abstract class QueryModel : IQueryModel
{
    public virtual long Id { set; get; }
    public virtual Guid EntityId { set; get; }
    protected QueryModel()
    {

    }
    protected QueryModel(long id)
    {
        Id = id;
    }
    protected QueryModel(Guid guid)
    {
        EntityId = guid;
    }
}

