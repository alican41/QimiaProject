using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Books;

namespace QimiaProject.Business.Implementations.Handlers.Books.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookManager _bookManager;

    public DeleteBookCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _bookManager.DeleteBookByIdAsync(request.BookId, cancellationToken);

        return Unit.Value;
    }
}
