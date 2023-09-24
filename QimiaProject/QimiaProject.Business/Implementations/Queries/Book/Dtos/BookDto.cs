using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Queries.Book.Dtos;

public class BookDto
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? BookAuthor { get; set; }

    public BookStatus BookStatus { get; set; }
}
