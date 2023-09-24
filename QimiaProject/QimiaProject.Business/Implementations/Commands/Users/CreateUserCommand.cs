using MediatR;
using QimiaProject.Business.Implementations.Commands.Users.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Users;

public class CreateUserCommand : IRequest<int>
{
    public CreateUserDto User { get; set; }

    public CreateUserCommand(
        CreateUserDto user)
    {
        User = user;
    }
}
