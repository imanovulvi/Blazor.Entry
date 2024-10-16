
namespace Dictionary.Common.DTOs.Queries.Entry.Get;

public class GetEntryContentQueryRequest
{
    private int page;
    public int Page {
        get
        {
            return (page*PageSize)-PageSize;
        }
        set
        {
            page = value;
        }
    }
    public int PageSize { get; set; }
}
