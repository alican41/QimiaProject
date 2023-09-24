using QimiaProject.DataAccess.Entities;

namespace QimiaProject.DataAccess.Repositories.Abstractions;

public interface IBookRepository : IRepositoryBase<Book>
{
    Task<List<Book>> GetByBookNameAsync(string bookname, string bookauthor, CancellationToken cancellationToken = default);


}
