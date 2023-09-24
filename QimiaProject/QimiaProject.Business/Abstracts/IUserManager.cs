using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Abstracts;

public interface IUserManager
{
    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    
    public Task<string> GetToken();
    public Task CreateUserAsync(
        User user,
        CancellationToken cancellationToken);

    public Task<User> GetUserByUserNoAsync(
        long userno,
        CancellationToken cancellationToken);

    public Task DeleteUserByUserNoAsync(
        long userno,
        CancellationToken cancellationToken);

    public Task UpdateUserAsync(
        long userno,
        User user,
        CancellationToken cancellationToken);
        
}
