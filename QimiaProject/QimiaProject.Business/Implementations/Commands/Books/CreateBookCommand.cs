using MediatR;
using QimiaProject.Business.Implementations.Commands.Books.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Books;

public class CreateBookCommand : IRequest<int>
{
    public CreateBookDto Book { get; set; }

    public CreateBookCommand(CreateBookDto book)
    {
        Book = book;
    }
}
