using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.User;
using QimiaProject.Business.Implementations.Queries.User.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Users.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserManager userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userManager.GetAllUsersAsync(cancellationToken);

        return users.Select(s => _mapper.Map<UserDto>(s)).ToList();
    }
}
