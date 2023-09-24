using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.DataAccess.Repositories.Implementations;

public class ReservationRepository : RepositoryBase<Reservation> , IReservationRepository
{
    public ReservationRepository(QimiaProjectDbContext dbContext) : base(dbContext)
    {
    }
}
