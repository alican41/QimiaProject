using MediatR;
using QimiaProject.Business.Implementations.Commands.Requests.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Requests;

public class UpdateRequestCommand : IRequest<Unit>
{
    public int RequestId { get; }
    public UpdateRequestDto Request { get; set; }

    public UpdateRequestCommand(int requestId, UpdateRequestDto request)
    {
        RequestId = requestId;
        Request = request;
    }
}
