using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Users;

namespace QimiaProject.Business.Implementations.Handlers.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserManager _userManager;

    public DeleteUserCommandHandler(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userManager.DeleteUserByUserNoAsync(request.UserNo, cancellationToken);
        // buradan UserManager a orda userrepository kısmına repoda isdeleted çalışır.
        return Unit.Value;
    }
}
