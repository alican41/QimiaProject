using MediatR;
using QimiaProject.Business.Implementations.Commands.Requests.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Requests;

public class CreateRequestCommand : IRequest<int>
{
    public CreateRequestDto Request { get; set; }

    public CreateRequestCommand(CreateRequestDto request)
    {
        Request = request;
    }
}
