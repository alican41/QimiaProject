using MediatR;
using QimiaProject.Business.Implementations.Queries.User.Dtos;

namespace QimiaProject.Business.Implementations.Queries.User;

public class GetUsersQuery : IRequest<List<UserDto>>
{

}
