namespace BaseSource.Core.Application.Common.Models;

public interface IBaseView
{
    Guid EntityId { get; set; }
}

public abstract class BaseView : IBaseView
{
    public Guid EntityId { get; set; }
}


