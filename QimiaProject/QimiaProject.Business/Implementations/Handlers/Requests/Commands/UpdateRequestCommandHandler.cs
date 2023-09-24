using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Requests;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Requests.Commands;

public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Unit>
{
    private readonly IRequestManager _requestManager;
    private readonly IMapper _mapper;

    public UpdateRequestCommandHandler(IRequestManager requestManager, IMapper mapper)
    {
        _requestManager = requestManager;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateRequestCommand requestt, CancellationToken cancellationToken)
    {
        var request = await _requestManager.GetRequestByIdAsync(requestt.RequestId, cancellationToken);
       
        request.RequestStatus = _mapper.Map<RequestStatus>(requestt.Request.RequestStatus);

        await _requestManager.UpdateRequestAsync(requestt.RequestId, request, cancellationToken);

        return Unit.Value;


    }
}
