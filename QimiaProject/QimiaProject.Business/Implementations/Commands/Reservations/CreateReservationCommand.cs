using MediatR;
using QimiaProject.Business.Implementations.Commands.Reservations.Dtos;

namespace QimiaProject.Business.Implementations.Commands.Reservations;

public class CreateReservationCommand : IRequest<int>
{
    public CreateReservationDto Reservation { get; set; }
   


    public CreateReservationCommand(CreateReservationDto reservation)
    {
        Reservation = reservation;
        
    }
}
