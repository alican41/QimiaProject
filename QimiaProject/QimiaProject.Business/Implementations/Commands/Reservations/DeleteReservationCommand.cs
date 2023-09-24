using MediatR;

namespace QimiaProject.Business.Implementations.Commands.Reservations;

public class DeleteReservationCommand : IRequest<Unit>
{
    public int ReservationId { get; }

    public DeleteReservationCommand(int reservationId)
    {
        ReservationId = reservationId;
    }
}
