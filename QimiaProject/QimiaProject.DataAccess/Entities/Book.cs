
namespace QimiaProject.DataAccess.Entities;

public class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = string.Empty;
    public string BookAuthor { get; set; } = string.Empty;

    public BookStatus BookStatus { get; set; }
}
