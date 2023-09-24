using MediatR;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;

namespace QimiaProject.Business.Implementations.Queries.Reservation;

public class GetReservationsQuery : IRequest<List<ReservationDto>>
{
}
