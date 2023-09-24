using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Abstracts;

public interface IReservationManager
{
    public Task<List<Reservation>> GetAllReservationsAsync(CancellationToken cancellationToken);

    public Task CreateReservationAsync(
        Reservation reservation,
        CancellationToken cancellationToken);

    public Task<Reservation> GetReservationByIdAsync(
        int reservationId,
        CancellationToken cancellationToken);

    public Task DeleteReservationByIdAsync(
        int reservationId,
        CancellationToken cancellationToken);

    public Task UpdateReservationAsync(
        Reservation reservation,
        CancellationToken cancellationToken);
}
