using MediatR;
using Microsoft.AspNetCore.Mvc;
using QimiaProject.Business.Implementations.Commands.Reservations.Dtos;
using QimiaProject.Business.Implementations.Commands.Reservations;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;
using QimiaProject.Business.Implementations.Queries.Reservation;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace QimiaProject.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ReservationsController : Controller
{
    private readonly IMediator _mediator;
    private string userEmail = AuthController.UserTokenEmail;
    private string userPassword = AuthController.UserTokenPassword;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateReservation(
        [FromBody] CreateReservationDto reservation,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateReservationCommand(reservation), cancellationToken);

        return CreatedAtAction(
            nameof(GetReservation),
            new { ReservationId = response },
            reservation);
    }

    [HttpGet("{ReservationId}")]
    public Task<ReservationDto> GetReservation(
        [FromRoute] int ReservationId,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetReservationQuery(ReservationId),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<ReservationDto>> GetReservations(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetReservationsQuery(),
            cancellationToken);
    }

    [HttpPut("{ReservationId}")]
    public async Task<ActionResult> UpdateReservation(
        [FromRoute] int ReservationId,
        [FromBody] UpdateReservationDto reservation,
        CancellationToken cancellationToken)
    {
        //reservationId eşleştir Book hariç hepsi
        Debug.Write(userEmail);
        Debug.Write(userPassword);
        await _mediator.Send(
            new UpdateReservationCommand(ReservationId, reservation),
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{ReservationId}")]
    public async Task<ActionResult> DeleteReservation(
        [FromRoute] int ReservationId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteReservationCommand(ReservationId),
            cancellationToken);

        return NoContent();
    }
}
