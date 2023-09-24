using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.User;
using QimiaProject.Business.Implementations.Queries.User.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserManager userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByUserNoAsync(request.UserNo, cancellationToken);

        return _mapper.Map<UserDto>(user);
    }

}
