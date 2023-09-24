using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Queries.Request.Dtos;

public class RequestDto
{
    public int RequestId { get; set; }

    public long UserNo { get; set; }

    public string? BookName { get; set; }

    public string? BookAuthor { get; set; }

    public RequestStatus RequestStatus { get; set; }
}
