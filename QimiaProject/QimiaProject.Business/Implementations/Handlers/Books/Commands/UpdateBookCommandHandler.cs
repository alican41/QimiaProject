using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Books;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Books.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookManager.GetBookByIdAsync(request.BookId, cancellationToken);

        book.BookName = request.Book.BookName ?? book.BookName;
        book.BookAuthor = request.Book.BookAuthor ?? book.BookAuthor;
        book.BookStatus = _mapper.Map<BookStatus>(request.Book.BookStatus);

        await _bookManager.UpdateBookAsync(request.BookId, book, cancellationToken);
        return Unit.Value;
    }
}
