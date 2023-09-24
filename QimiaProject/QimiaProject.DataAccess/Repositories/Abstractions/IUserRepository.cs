using QimiaProject.DataAccess.Entities;

namespace QimiaProject.DataAccess.Repositories.Abstractions;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User> GetByUserNoAsync(long userno, CancellationToken cancellationToken = default);
    Task<User> GetByUserEmailAsync(string email, CancellationToken cancellationToken = default);
}
