using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Requests;

namespace QimiaProject.Business.Implementations.Handlers.Requests.Commands;

public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Unit>
{
    private readonly IRequestManager _requestManager;

    public DeleteRequestCommandHandler(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
    {
        await _requestManager.DeleteRequestByIdAsync(request.RequestId, cancellationToken);

        return Unit.Value;
    }
}
