using Microsoft.EntityFrameworkCore;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Exceptions;
using QimiaProject.DataAccess.Repositories.Abstractions;
using System.Linq;

namespace QimiaProject.DataAccess.Repositories.Implementations;

public class BookRepository : RepositoryBase<Book> , IBookRepository
{
    protected QimiaProjectDbContext DbContext { get; set; }

    private readonly DbSet<Book> DbSet;
    public BookRepository(QimiaProjectDbContext dbContext) : base(dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = dbContext.Set<Book>();
    }
    

    public async Task<List<Book>> GetByBookNameAsync(
    string bookName,
    string bookAuthor,
    CancellationToken cancellationToken = default)
    {
        var result =  DbSet.Where(
                b => b.BookName == bookName && b.BookAuthor == bookAuthor && b.BookStatus != BookStatus.isdeleted);
        return result.ToList() ??
                throw new EntityNotFoundException<Book>(bookName + " " + bookAuthor);

    }

   
    

}
