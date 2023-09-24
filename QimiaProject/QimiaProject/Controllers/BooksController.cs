using MediatR;
using Microsoft.AspNetCore.Mvc;
using QimiaProject.Business.Implementations.Commands.Books.Dtos;
using QimiaProject.Business.Implementations.Commands.Books;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;
using QimiaProject.Business.Implementations.Queries.Book;
using Microsoft.AspNetCore.Authorization;

namespace QimiaProject.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class BooksController : Controller
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> CreateBook(
        [FromBody] CreateBookDto book,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateBookCommand(book), cancellationToken);

        return CreatedAtAction(
            nameof(GetBook),
            new { BookId = response },
            book);
    }

    [HttpGet("{BookId}")]
    public Task<BookDto> GetBook(
        [FromRoute] int BookId,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetBookQuery(BookId),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<BookDto>> GetBooks(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetBooksQuery(),
            cancellationToken);
    }

    [HttpPut("{BookId}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> UpdateBook(
        [FromRoute] int BookId,
        [FromBody] UpdateBookDto book,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateBookCommand(BookId, book),
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{BookId}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> DeleteBook(
        [FromRoute] int BookId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteBookCommand(BookId),
            cancellationToken);

        return NoContent();
    }
}
