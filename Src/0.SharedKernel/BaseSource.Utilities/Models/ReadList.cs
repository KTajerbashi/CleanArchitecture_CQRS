namespace BaseSource.Utilities.Models;

public class ReadList<TModel> : IListModel
{
    private int CountData;
    public ReadList(int count = 0)
    {
        CountData = count;
    }
    public IEnumerable<TModel> Data { get; set; }
    public void SetData(IEnumerable<TModel> data) => Data = data;
    public int Count
    {
        get => CountData == 0 ? Data.Count() : CountData;
        private set => value = value;
    }
}

