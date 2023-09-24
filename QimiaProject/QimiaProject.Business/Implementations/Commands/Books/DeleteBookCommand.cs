using MediatR;

namespace QimiaProject.Business.Implementations.Commands.Books;

public class DeleteBookCommand : IRequest<Unit>
{
    public int BookId { get; }

    public DeleteBookCommand(int bookId)
    {
        BookId = bookId;    
    }
}
