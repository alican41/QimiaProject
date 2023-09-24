namespace QimiaProject.Business.Implementations.Commands.Reservations.Dtos;

public class CreateReservationDto
{
    public long UserNo { get; set; }

    public string? BookName { get; set; }
    public string? BookAuthor { get; set; }

    public DateTime ReservationStartDate { get; set; }

  
}
