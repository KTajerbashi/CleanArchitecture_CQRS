namespace BaseSource.Utilities.Models;

public interface ITreeViewModel<T>
    where T : class
{
    long Id { get; set; }
    long? ParentId { get; set; }
    List<T> Children { get; set; }
}

