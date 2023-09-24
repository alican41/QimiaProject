using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Books;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Books.Commands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookManager _bookManager;

    public CreateBookCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            BookName = request.Book.BookName ?? string.Empty,
            BookAuthor = request.Book.BookAuthor ?? string.Empty,
        };

        await _bookManager.CreateBookAsync(book, cancellationToken);

        return book.BookId;
    }
}
