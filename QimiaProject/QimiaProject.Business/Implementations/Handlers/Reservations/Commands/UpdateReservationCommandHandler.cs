using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Reservations;

namespace QimiaProject.Business.Implementations.Handlers.Reservations.Commands;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
{
    private readonly IReservationManager _reservationManager;
    
    public UpdateReservationCommandHandler(IReservationManager reservationManager)
    {
        _reservationManager = reservationManager;
    }
    
    public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var oldReservation = await _reservationManager.GetReservationByIdAsync(request.ReservationId, cancellationToken);

        oldReservation.ReservationStartDate = request.Reservation.ReservationStartDate;
        oldReservation.ReservationEndDate = request.Reservation.ReservationEndDate;

        await _reservationManager.UpdateReservationAsync(oldReservation, cancellationToken);

        return Unit.Value;
    }
}
