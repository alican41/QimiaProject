
namespace QimiaProject.DataAccess.Entities;

public class Reservation
{
    public int ReservationId { get; set; }

    public long UserNo { get; set; }

    public int BookId { get; set; }

    public string BookName { get; set; } = string.Empty;

    public string BookAuthor { get; set; } = string.Empty;

    public DateTime ReservationStartDate { get; set; }

    public DateTime ReservationEndDate { get; set;}
}
