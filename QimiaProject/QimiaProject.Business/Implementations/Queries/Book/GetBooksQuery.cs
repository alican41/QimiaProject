using MediatR;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Book;

public class GetBooksQuery : IRequest<List<BookDto>>
{
}
