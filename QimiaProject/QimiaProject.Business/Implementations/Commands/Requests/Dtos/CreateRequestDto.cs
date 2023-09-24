namespace QimiaProject.Business.Implementations.Commands.Requests.Dtos;

public class CreateRequestDto
{
    public long UserNo { get; set; }

    public string? BookName { get; set; }

    public string? BookAuthor { get; set; }

}
