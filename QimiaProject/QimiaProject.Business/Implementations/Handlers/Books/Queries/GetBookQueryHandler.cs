using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Book;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Books.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookManager.GetBookByIdAsync(request.BookId, cancellationToken);

        return _mapper.Map<BookDto>(book);
    }
}
