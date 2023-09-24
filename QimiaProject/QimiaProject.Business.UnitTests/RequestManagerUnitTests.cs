using Moq;
using QimiaProject.Business.Implementations;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.Business.UnitTests;

[TestFixture]
internal class RequestManagerUnitTests
{
    private readonly Mock<IRequestRepository> _mockRequestRepository;
    private readonly RequestManager _requestManager;

    public RequestManagerUnitTests()
    {
        _mockRequestRepository = new Mock<IRequestRepository>();
        _requestManager = new RequestManager(_mockRequestRepository.Object);
    }

    [Test]
    public async Task CreateRequestAsync_WhenCalled_CallsRepository()
    {
        var testRequest = new Request
        {
            UserNo = 123456789,
            BookName = "Test",
            BookAuthor = "Test",
        };

        await _requestManager.CreateRequestAsync(testRequest, default);

        _mockRequestRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Request>(s => s == testRequest),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateRequestAsync_WhenRequestIdHasValue_RemovesAndCallsRepository()
    {
        var testRequest = new Request
        {
            RequestId = 1,
            UserNo = 123456789,
            BookName = "Test",
            BookAuthor = "Test",
        };

        await _requestManager.CreateRequestAsync(testRequest, default);

        _mockRequestRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<Request>(s => s == testRequest),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateRequestAsync_WhenCalled_CallsRepository()
    {
        _mockRequestRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new Request
            {
                RequestId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                UserNo = 123456789
            });

        var testRequestUpdate = new Request
        {
            RequestStatus = RequestStatus.accepted
        };

        await _requestManager.UpdateRequestAsync(testRequestUpdate.RequestId, testRequestUpdate, default);

        _mockRequestRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Request>(s => s == testRequestUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateRequestAsync_WhenRequestIdHasValue_RemovesAndCallsRepository()
    {
        var testRequestUpdate = new Request
        {
            RequestId = 1,
            RequestStatus = RequestStatus.accepted
        };

        await _requestManager.UpdateRequestAsync(testRequestUpdate.RequestId, testRequestUpdate, default);

        _mockRequestRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Request>(s => s == testRequestUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteRequestAsync_WhenCalled_CallsRepository()
    {
        _mockRequestRepository.Setup(repo => repo.GetByIdAsync(
            It.IsAny<int>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new Request
            {
                RequestId = 1,
                BookName = "Test",
                BookAuthor = "Test",
                UserNo = 123456789
            });

        
        await _requestManager.DeleteRequestByIdAsync(1, default);

        _mockRequestRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<Request>(s => s.RequestStatus == RequestStatus.isdeleted),
                It.IsAny<CancellationToken>()), Times.Once);
    }
}