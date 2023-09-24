using MediatR;
using QimiaProject.Business.Implementations.Commands.Books.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Books;

public class UpdateBookCommand : IRequest<Unit>
{
    public int BookId { get; }
    public UpdateBookDto Book { get; set; }

    public UpdateBookCommand(int bookId,UpdateBookDto book)
    {
        BookId = bookId;
        Book = book;
    }
}
