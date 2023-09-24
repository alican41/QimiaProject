using QimiaProject.Business.Abstracts;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;
using System.Net;

namespace QimiaProject.Business.Implementations;

public class BookManager : IBookManager
{
    private readonly IBookRepository _bookRepository;

    public BookManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        return _bookRepository.GetAllAsync(cancellationToken);
    }

    public Task CreateBookAsync(
        Book book,
        CancellationToken cancellationToken)
    {
        book.BookId = default;
        book.BookStatus = BookStatus.ontheshelf;

        return _bookRepository.CreateAsync(book, cancellationToken);
    }

    

    public async Task<Book> GetBookByIdAsync(
        int BookId,
        CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(BookId, cancellationToken);

        return book;
    }

    public async Task DeleteBookByIdAsync(
        int BookId,
        CancellationToken cancellationToken)
    {
        var entity = await _bookRepository.GetByIdAsync(BookId, cancellationToken);
        entity.BookStatus = BookStatus.isdeleted;
        await _bookRepository.UpdateAsync(entity, cancellationToken);
   
        
    }

    public async Task UpdateBookAsync(
        int bookId,
        Book book,
        CancellationToken cancellationToken)
    {
        var oldBook = await _bookRepository.GetByIdAsync(bookId, cancellationToken);

        switch (oldBook.BookStatus)
        {
            case BookStatus.isdeleted:
                throw new Exception("Yanlış bilgi girildi. Kitap durumu uygun değil.");
            default:
                await _bookRepository.UpdateAsync(book, cancellationToken);
                break;
        }

    }


}
