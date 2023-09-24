using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Users;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserManager userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByUserNoAsync(request.UserNo, cancellationToken);

        user.UserFName = request.User.UserFName ?? user.UserFName;
        user.UserLName = request.User.UserLName ?? user.UserLName;
        user.UserStatus = _mapper.Map<UserStatus>(request.User.UserStatus);

        await _userManager.UpdateUserAsync(request.UserNo,user, cancellationToken);

        return Unit.Value;
    }
}
