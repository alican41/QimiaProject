using MediatR;
using QimiaProject.Business.Implementations.Queries.User.Dtos;

namespace QimiaProject.Business.Implementations.Queries.User;

public class GetUserQuery : IRequest<UserDto>
{
    public long UserNo { get; }

    public GetUserQuery(long userNo)
    {
        UserNo = userNo;
    }

   
}
