using MediatR;

namespace QimiaProject.Business.Implementations.Commands.Users;

public class DeleteUserCommand : IRequest<Unit>
{
    public long UserNo { get; }

    public DeleteUserCommand(long userNo)
    {
        UserNo = userNo;
    }
}
