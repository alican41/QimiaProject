using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Request;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Requests.Queries;

public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, RequestDto>
{
    private readonly IRequestManager _requestManager;
    private readonly IMapper _mapper;

    public GetRequestQueryHandler(IRequestManager requestManager, IMapper mapper)
    {
        _requestManager = requestManager;
        _mapper = mapper;
    }

    public async Task<RequestDto> Handle(GetRequestQuery requestt,CancellationToken cancellationToken)
    {
        var request = await _requestManager.GetRequestByIdAsync(requestt.RequestId, cancellationToken);

        return _mapper.Map<RequestDto>(request);
    }
}
