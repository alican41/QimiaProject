using MediatR;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Request;

public class GetRequestsQuery : IRequest<List<RequestDto>>
{
}
