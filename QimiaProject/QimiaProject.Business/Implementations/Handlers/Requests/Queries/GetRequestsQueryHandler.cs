using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Request;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Requests.Queries;

public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, List<RequestDto>>
{
    private readonly IRequestManager _requestManager;
    private readonly IMapper _mapper;

    public GetRequestsQueryHandler(IRequestManager requestManager, IMapper mapper)
    {
        _requestManager = requestManager;
        _mapper = mapper;
    }

    public async Task<List<RequestDto>> Handle(GetRequestsQuery requestt, CancellationToken cancellationToken)
    {
        var requests = await _requestManager.GetAllRequestsAsync(cancellationToken);

        return requests.Select(s => _mapper.Map <RequestDto>(s)).ToList();
    }
}
