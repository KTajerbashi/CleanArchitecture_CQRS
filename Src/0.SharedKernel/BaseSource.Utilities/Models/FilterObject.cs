using Dapper;
using System.Text;

namespace BaseSource.Utilities.Models;

public class FilterObject
{
    public FilterObject()
    {

    }
    public void SetInnerWhere(string innerWhere)
    {
        InnerWhere = innerWhere;
        IsClient = false;
        Parameters = new();
    }
    public bool IsClient { get; private set; } = true;
    public string InnerWhere { get; set; } = string.Empty;
    public void AddInnerCondition(string condition)
    {
        var innerString = new StringBuilder();
        innerString.Append(InnerWhere);
        innerString.Append(string.Format(" {0} ", condition));
        InnerWhere = innerString.ToString();
    }
    public bool NeedTotalCount { get; set; } = true;
    public int TotalCount { get; set; }
    public int PageNumber { get; set; } = 1;
    public int Take { get; set; } = 10;
    public string SearchValue { get; set; } = string.Empty;
    public int Skip => (PageNumber - 1) * Take;
    public bool SortAscending { get; set; }
    public bool IgnoreIsActive { get; set; }
    public void SetIgnoreIsActive(bool value) => IgnoreIsActive = value;
    public string DirectionSort { get; set; } = "ASC";
    public string Paging { get => $@" OFFSET ({PageNumber - 1}) * {Take} ROWS FETCH NEXT {Take} ROWS ONLY;"; }
    public string ColumnSort { get; set; } = "Id";
    public DynamicParameters Parameters { get; private set; }
    public void AddParameter(string name, object value)
        => Parameters.Add(name, value);
}

