using MediatR;
using QimiaProject.Business.Implementations.Commands.Users.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Users;

public class UpdateUserCommand : IRequest<Unit>
{
    public long UserNo { get;}
    public UpdateUserDto User { get; set; }

    public UpdateUserCommand(long userNo, UpdateUserDto user)
    {
        UserNo = userNo;
        User = user;
    }
}
