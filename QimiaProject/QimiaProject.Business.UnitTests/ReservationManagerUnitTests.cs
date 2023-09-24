using Moq;
using QimiaProject.Business.Implementations;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.Business.UnitTests;

[TestFixture]
internal class ReservationManagerUnitTests
{
    private readonly Mock<IReservationRepository> _mockReservationRepository;
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly ReservationManager _reservationManager;
    private readonly BookManager _bookManager;

    public ReservationManagerUnitTests()
    {
        _mockReservationRepository = new Mock<IReservationRepository>();
        _mockBookRepository = new Mock<IBookRepository>();
     //   _reservationManager = new ReservationManager(_mockReservationRepository.Object, _mockBookRepository.Object);
        _bookManager = new BookManager(_mockBookRepository.Object);
    }

    [Test]
    public async Task CreateReservationAsync_WhenCalled_CallsRepository()
    {
        _mockBookRepository.Setup(repo => repo.GetByBookNameAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()))
                               .ReturnsAsync(new List<Book> { new() { BookId = 1, BookName = "Mocked Book", BookAuthor = "Author Book" }  });
        
        var testReservation = new Reservation
        {
            UserNo = 774310793,
            BookName = "Mocked Book",
            BookAuthor = "Author Book",
            ReservationStartDate = DateTime.Now
        };

        await _reservationManager.CreateReservationAsync(testReservation, default);

        _mockReservationRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Reservation>(s => s == testReservation),
                It.IsAny<CancellationToken>()), Times.Once);

        

    }

    [Test]
    public async Task CreateReservationAsync_WhenReservationIdHasValue_RemovesAndCallsRepository()
    {
        _mockBookRepository.Setup(repo => repo.GetByBookNameAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()))
                               .ReturnsAsync(new List<Book> { new() { BookId = 1, BookName = "Mocked Book", BookAuthor = "Author Book" } });

        var testReservation = new Reservation
        {
            ReservationId = 1,
            UserNo = 774310793,
            BookName = "Mocked Book",
            BookAuthor = "Author Book",
            ReservationStartDate = DateTime.Now
        };

        await _reservationManager.CreateReservationAsync(testReservation, default);

        _mockReservationRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Reservation>(s => s == testReservation),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateReservationAsync_WhenCalled_CallsRepository()
    {
        _mockReservationRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                               .ReturnsAsync(
            new Reservation
            {
                ReservationId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                BookId = 1,
                UserNo = 123456789,
                ReservationStartDate = DateTime.Now,
                
            });

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

        _mockReservationRepository.Setup(repo => repo.GetAllAsync(
            It.IsAny<CancellationToken>()))
                               .ReturnsAsync(new List<Reservation> { new() 
                               {    ReservationId = 1,
                                    BookName = "Test",
                                    BookAuthor = "Test",
                                    BookId = 1,
                                    UserNo = 123456789,
                                    ReservationStartDate = DateTime.Now} });

        var testReservationUpdate = new Reservation
        {
        
            ReservationStartDate = DateTime.Now,
            ReservationEndDate = DateTime.Now.AddDays(7)
        };

        await _reservationManager.UpdateReservationAsync(testReservationUpdate, default);

        _mockReservationRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Reservation>(s => s == testReservationUpdate),
                It.IsAny<CancellationToken>()), Times.Once);



    }

    [Test]
    public async Task UpdateReservationAsync_WhenReservationIdHasValue_RemovesAndCallsRepository()
    {
        _mockReservationRepository.Setup(repo => repo.GetByIdAsync(
             It.IsAny<int>(),
             It.IsAny<CancellationToken>()))
                                .ReturnsAsync(
             new Reservation
             {
                 ReservationId = 1,
                 BookName = "Test",
                 BookAuthor = "Test",
                 BookId = 1,
                 UserNo = 123456789,
                 ReservationStartDate = DateTime.Now,

             });

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

        _mockReservationRepository.Setup(repo => repo.GetAllAsync(
            It.IsAny<CancellationToken>()))
                               .ReturnsAsync(new List<Reservation> { new()
                               {    ReservationId = 1,
                                    BookName = "Test",
                                    BookAuthor = "Test",
                                    BookId = 1,
                                    UserNo = 123456789,
                                    ReservationStartDate = DateTime.Now} });

        var testReservationUpdate = new Reservation
        {
            ReservationId = 1,
            ReservationStartDate = DateTime.Now,
            ReservationEndDate = DateTime.Now.AddDays(7)
        };

        await _reservationManager.UpdateReservationAsync(testReservationUpdate, default);

        _mockReservationRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Reservation>(s => s == testReservationUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteReservationAsync_WhenCalled_CallsRepository()
    {

        _mockReservationRepository.Setup(repo => repo.DeleteByIdAsync(
       It.IsAny<int>(),
       It.IsAny<CancellationToken>()));
       

        // Act
        await _reservationManager.DeleteReservationByIdAsync(1, default);

        // Assert
        _mockReservationRepository.Verify(sr => sr.DeleteByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()), Times.Once);



    }
}