
namespace QimiaProject.DataAccess.Entities;

public class Request
{
    public int RequestId { get; set; }

    public long UserNo { get; set; }

    public string BookName { get; set; } = string.Empty;

    public string BookAuthor { get; set; } = string.Empty;

    public RequestStatus RequestStatus { get; set; }
}
