using MediatR;

namespace QimiaProject.Business.Implementations.Commands.Requests;

public class DeleteRequestCommand : IRequest<Unit>
{
    public int RequestId { get; }

    public DeleteRequestCommand(int requestId)
    {
        RequestId = requestId;
    }
}
