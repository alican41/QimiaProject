using MediatR;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Book;

public class GetBookQuery : IRequest<BookDto>
{
    public int BookId { get; }

    public GetBookQuery(int bookId)
    {
        BookId = bookId;
    }
}
