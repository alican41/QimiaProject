using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Reservations;

namespace QimiaProject.Business.Implementations.Handlers.Reservations.Commands;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
{
    private readonly IReservationManager _reservationManager;

    public DeleteReservationCommandHandler(IReservationManager reservationManager)
    {
        _reservationManager = reservationManager;
    }

    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationManager.DeleteReservationByIdAsync(request.ReservationId, cancellationToken);

        return Unit.Value;
    }
}
