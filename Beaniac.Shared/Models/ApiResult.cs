namespace Beaniac.Shared.Models;
public class ApiResult<T>
{
    public List<T>? Items { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
public bool HasMorePages => PageNumber * Items?.Count < TotalCount;
}