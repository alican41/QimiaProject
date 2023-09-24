using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Abstracts;

public interface IBookManager
{
    public Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken);

    public Task CreateBookAsync(
        Book book,
        CancellationToken cancellationToken);


    public Task<Book> GetBookByIdAsync(
        int BookId,
        CancellationToken cancellationToken);

    public Task DeleteBookByIdAsync(
        int BookId,
        CancellationToken cancellationToken);

    public Task UpdateBookAsync(
        int BookId,
        Book book,
        CancellationToken cancellationToken);
}
