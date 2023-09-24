using MediatR;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Request;

public class GetRequestQuery : IRequest<RequestDto>
{
    public int RequestId { get; }

    public GetRequestQuery(int requestId)
    {
        RequestId = requestId;
    }
}
