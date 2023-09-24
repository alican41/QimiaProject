using System.Linq.Expressions;

namespace QimiaProject.DataAccess.Repositories.Abstractions;

public interface IRepositoryBase<T> where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<T> GetByIdAsync(int id,CancellationToken cancellationToken=default);
    Task DeleteByIdAsync(int id,CancellationToken cancellationToken=default);
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

}
