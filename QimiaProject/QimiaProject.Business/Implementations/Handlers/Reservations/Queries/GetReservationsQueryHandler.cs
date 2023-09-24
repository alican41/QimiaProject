using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Reservation;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Reservations.Queries;

public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationManager _reservationManager;
    private readonly IMapper _mapper;

    public GetReservationsQueryHandler(IReservationManager reservationManager, IMapper mapper)
    {
        _reservationManager = reservationManager;
        _mapper = mapper;
    }

    public async Task<List<ReservationDto>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationManager.GetAllReservationsAsync(cancellationToken);

        return reservations.Select(s => _mapper.Map <ReservationDto>(s)).ToList();
    }
}
