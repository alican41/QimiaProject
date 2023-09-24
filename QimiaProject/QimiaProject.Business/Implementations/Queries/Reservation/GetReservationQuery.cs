using MediatR;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Reservation;

public class GetReservationQuery : IRequest<ReservationDto>
{
    public int ReservationId { get; }

    public GetReservationQuery(int  reservationId)
    {
        ReservationId = reservationId;
    }
}
