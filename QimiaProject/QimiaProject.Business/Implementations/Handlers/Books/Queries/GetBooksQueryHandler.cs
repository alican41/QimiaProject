using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Book;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Books.Queries;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookManager.GetAllBooksAsync(cancellationToken);

        return books.Select(s => _mapper.Map <BookDto>(s)).ToList();
    }
}
