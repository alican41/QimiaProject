using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Commands.Books.Dtos;

public class UpdateBookDto
{
    public string? BookName { get; set; }
    public string? BookAuthor { get; set; }
    public BookStatus BookStatus { get; set; }
}
