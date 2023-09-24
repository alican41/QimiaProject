using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QimiaProject.Business.Implementations.Commands.Users;
using QimiaProject.Business.Implementations.Commands.Users.Dtos;
using QimiaProject.Business.Implementations.Queries.User;
using QimiaProject.Business.Implementations.Queries.User.Dtos;
using System.Data;

namespace QimiaProject.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> CreateUser(
        [FromBody] CreateUserDto user,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateUserCommand(user), cancellationToken);

        return CreatedAtAction(
            nameof(GetUser),
            new { UserNo = response },
            user);
    }

    [HttpGet("{userNo}")]
  
    public Task<UserDto> GetUser(
        [FromRoute] long userNo,
        CancellationToken cancellationToken)
    {
        
        return _mediator.Send(
            new GetUserQuery(userNo),
            cancellationToken);
    }

    [HttpGet]
    [Authorize(Policy = "PermissionPolicy")]
    public Task<List<UserDto>> GetUsers(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetUsersQuery(),
            cancellationToken);
    }

    [HttpPut("{userNo}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute] long userNo,
        [FromBody] UpdateUserDto user,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateUserCommand(userNo, user),
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{userNo}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> DeleteUser(
        [FromRoute] long userNo,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteUserCommand(userNo),
            cancellationToken);

        return NoContent();
    }



}
