using MediatR;
using Microsoft.AspNetCore.Mvc;
using QimiaProject.Business.Implementations.Commands.Requests.Dtos;
using QimiaProject.Business.Implementations.Commands.Requests;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;
using QimiaProject.Business.Implementations.Queries.Request;
using Microsoft.AspNetCore.Authorization;

namespace QimiaProject.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class RequestsController : Controller
{
    private readonly IMediator _mediator;

    public RequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateRequest(
        [FromBody] CreateRequestDto request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateRequestCommand(request), cancellationToken);

        return CreatedAtAction(
            nameof(GetRequest),
            new { RequestId = response },
            request);
    }

    [HttpGet("{RequestId}")]
    [Authorize(Policy = "PermissionPolicy")]
    public Task<RequestDto> GetRequest(
        [FromRoute] int RequestId,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetRequestQuery(RequestId),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<RequestDto>> GetRequests(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetRequestsQuery(),
            cancellationToken);
    }

    [HttpPut("{RequestId}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> UpdateRequest(
        [FromRoute] int RequestId,
        [FromBody] UpdateRequestDto request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateRequestCommand(RequestId, request),
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{RequestId}")]
    [Authorize(Policy = "PermissionPolicy")]
    public async Task<ActionResult> DeleteRequest(
        [FromRoute] int RequestId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteRequestCommand(RequestId),
            cancellationToken);

        return NoContent();
    }

}
