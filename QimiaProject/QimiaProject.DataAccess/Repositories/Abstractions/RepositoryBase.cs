using Microsoft.EntityFrameworkCore;
using QimiaProject.DataAccess.Exceptions;

namespace QimiaProject.DataAccess.Repositories.Abstractions;

public abstract class RepositoryBase<T> where T : class
{
    protected QimiaProjectDbContext DbContext { get; set; }

    private readonly DbSet<T> DbSet;

    protected RepositoryBase(QimiaProjectDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }


    

    public async Task<T> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {

        return await DbSet.FindAsync(
            id,
            cancellationToken) ??
            throw new EntityNotFoundException<T>(id);
    }

    

    public async Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        DbContext.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateAsync(
        T entity,
        CancellationToken cancellationToken)
    {
        await DbSet.AddAsync(
            entity,
            cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        T entity,
        CancellationToken cancellationToken)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        T entity,
        CancellationToken cancellationToken)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }


}
