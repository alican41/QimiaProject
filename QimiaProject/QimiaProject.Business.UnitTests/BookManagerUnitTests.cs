using Moq;
using QimiaProject.Business.Implementations;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.Business.UnitTests;

[TestFixture]
internal class BookManagerUnitTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly BookManager _bookManager;

    public BookManagerUnitTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _bookManager = new BookManager(_mockBookRepository.Object);
    }

    [Test]
    public async Task CreateBookAsync_WhenCalled_CallsRepository()
    {
        var testBook = new Book
        {
            BookName = "Test",
            BookAuthor = "Test"
        };

        await _bookManager.CreateBookAsync(testBook, default);

        _mockBookRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Book>(s => s == testBook),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateBookAsync_WhenBookIdHasValue_RemovesAndCallsRepository()
    {
        var testBook = new Book
        {
            BookId = 1,
            BookName = "Test",
            BookAuthor = "Test"
        };

        await _bookManager.CreateBookAsync(testBook, default);

        _mockBookRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Book>(s => s == testBook),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateBookAsync_WhenCalled_CallsRepository()
    {
        _mockBookRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new Book
            {
                BookId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                BookStatus = BookStatus.ontheshelf
            });


        var testBookUpdate = new Book
        {
            BookName = "Test1",
            BookAuthor = "Test1",
            BookStatus = BookStatus.booked
        };

        await _bookManager.UpdateBookAsync(testBookUpdate.BookId, testBookUpdate, default);

        _mockBookRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Book>(s => s == testBookUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateBookAsync_WhenBookIdHasValue_RemovesAndCallsRepository()
    {
        _mockBookRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new Book
            {
                BookId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                BookStatus = BookStatus.ontheshelf
            });


        var testBookUpdate = new Book
        {
            BookId= 1,
            BookName = "Test1",
            BookAuthor = "Test1",
            BookStatus = BookStatus.booked
        };

        await _bookManager.UpdateBookAsync(testBookUpdate.BookId, testBookUpdate, default);

        _mockBookRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Book>(s => s == testBookUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteBookAsync_WhenCalled_CallsRepository()
    {
        _mockBookRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new Book
            {
                BookId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                BookStatus = BookStatus.ontheshelf
            });

        await _bookManager.DeleteBookByIdAsync(1, default);

        _mockBookRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Book>(s => s.BookStatus == BookStatus.isdeleted),
                It.IsAny<CancellationToken>()), Times.Once);
    }
}