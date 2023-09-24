using MediatR;
using QimiaProject.Business.Implementations.Commands.Reservations.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Reservations;

public class UpdateReservationCommand : IRequest<Unit>
{
    public int ReservationId { get;}
    public UpdateReservationDto Reservation { get; set; }

    public UpdateReservationCommand(int reservationId, UpdateReservationDto reservation)
    {
        ReservationId = reservationId;
        Reservation = reservation;
    }
}
