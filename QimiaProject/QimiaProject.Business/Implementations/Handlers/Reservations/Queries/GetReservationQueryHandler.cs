using AutoMapper;
using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Queries.Reservation;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;

namespace QimiaProject.Business.Implementations.Handlers.Reservations.Queries;

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ReservationDto>
{
    private readonly IReservationManager _reservationManager;
    private readonly IMapper _mapper;

    public GetReservationQueryHandler(IReservationManager reservationManager, IMapper mapper)
    {
        _reservationManager = reservationManager;
        _mapper = mapper;
    }

    public async Task<ReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationManager.GetReservationByIdAsync(request.ReservationId, cancellationToken);

        return _mapper.Map<ReservationDto>(reservation);
    }
}
