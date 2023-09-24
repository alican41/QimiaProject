using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Users;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserManager _userManager;

    public CreateUserCommandHandler(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserFName = request.User.UserFName ?? string.Empty,
            UserLName = request.User.UserLName ?? string.Empty,
            UserEmail = request.User.UserEmail ?? string.Empty,
            UserPassword = request.User.UserPassword ?? string.Empty
            
        };

        await _userManager.CreateUserAsync(user, cancellationToken);

        return user.UserId;
    }
}
