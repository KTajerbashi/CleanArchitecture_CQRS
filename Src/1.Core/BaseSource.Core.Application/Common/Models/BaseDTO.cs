namespace BaseSource.Core.Application.Common.Models;
public interface IBaseDTO
{
    Guid EntityId { get; set; }
}

public abstract class BaseDTO : IBaseDTO
{
    public Guid EntityId { get; set; }
    public long Id { get; set; }
}
