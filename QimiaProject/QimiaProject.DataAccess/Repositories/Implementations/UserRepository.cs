using Microsoft.EntityFrameworkCore;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Exceptions;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.DataAccess.Repositories.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    protected QimiaProjectDbContext DbContext { get; set; }

    private readonly DbSet<User> DbSet;

    public UserRepository(QimiaProjectDbContext dbContext) : base(dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = dbContext.Set<User>();
    }

    public async Task<User> GetByUserNoAsync(
        long userno,
        CancellationToken cancellationToken = default)
    {

        return await DbSet.FirstOrDefaultAsync(
            u => u.UserNo == userno, cancellationToken) ??
            throw new EntityNotFoundException<User>(userno);
    }

    public async Task<User> GetByUserEmailAsync(
        string userEmail,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(
            u => u.UserEmail == userEmail, cancellationToken) ??
            throw new EntityNotFoundException<User>(userEmail);
    }
   
}
