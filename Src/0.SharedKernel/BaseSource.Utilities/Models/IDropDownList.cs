namespace BaseSource.Utilities.Models;

public interface IDropDownList
{
}

public class DropDownList<TKey> : QueryModel, IDropDownList
    where TKey : struct, IComparable,
    IComparable<TKey>,
    IConvertible,
    IEquatable<TKey>,
    IFormattable
{
    public DropDownList()
    {

    }
    public DropDownList(long Id, bool Selected, string Title, TKey Value)
    {
        this.Id = Id;
        this.Selected = Selected;
        this.Title = Title;
        this.Value = Value;
        Description = $"{Title} {Value} {Id}";
    }
    public DropDownList(long Id, bool Selected, string Title, TKey Value, string desc)
    {
        this.Id = Id;
        this.Selected = Selected;
        this.Title = Title;
        this.Value = Value;
        Description = desc;
    }
    public bool Selected { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TKey Value { get; set; }

}