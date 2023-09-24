using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Reservations;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Reservations.Commands;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
{
    private readonly IReservationManager _reservationManager;

    public CreateReservationCommandHandler(IReservationManager reservationManager)
    {
        _reservationManager = reservationManager;
    }

    public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation
        {
            BookName = request.Reservation.BookName ?? string.Empty,
            BookAuthor = request.Reservation.BookAuthor ?? string.Empty,
            UserNo = request.Reservation.UserNo,
            ReservationStartDate = request.Reservation.ReservationStartDate,
        };

        await _reservationManager.CreateReservationAsync(reservation, cancellationToken);

        return reservation.ReservationId;
       
    }
}
