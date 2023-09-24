using Moq;
using QimiaProject.Business.Implementations;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.Business.UnitTests;

[TestFixture]
internal class UserManagerUnitTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserManager _userManager;

    public UserManagerUnitTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userManager = new UserManager(_mockUserRepository.Object);
    }

    [Test]
    public async Task CreateUserAsync_WhenCalled_CallsRepository()
    {
        var testUser = new User
        {
            UserFName = "Test",
            UserLName = "Test",
            UserEmail = "Test",
            UserPassword = "Test",
        };

        await _userManager.CreateUserAsync(testUser, default);

        _mockUserRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<User>(s => s == testUser),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateUserAsync_WhenUserIdHasValue_RemovesAndCallsRepository()
    {
        var testUser = new User
        {
            UserId = 1,
            UserFName = "Test",
            UserLName = "Test",
            UserEmail = "Test",
            UserPassword = "Test",
        };

        await _userManager.CreateUserAsync(testUser, default);

        _mockUserRepository
            .Verify(
            sr => sr.CreateAsync(
                It.Is<User>(s => s == testUser),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateUserAsync_WhenCalled_CallsRepository()
    {

        _mockUserRepository.Setup(repo => repo.GetByUserNoAsync(
            It.IsAny<long>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new User { UserId = 1,
                UserFName = "Test",
                UserLName = "Test",
                UserEmail = "Test",
                UserPassword = "Test",
                UserNo = 123456789 });


        var testUserUpdate = new User
        {
            UserFName = "Test1",
            UserLName = "Test1",
            UserEmail = "Test1",
            UserPassword = "Test1",
            UserStatus = UserStatus.working
        };

        await _userManager.UpdateUserAsync(testUserUpdate.UserNo, testUserUpdate, default);

        _mockUserRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<User>(s => s == testUserUpdate),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateUserAsync_WhenUserIdHasValue_RemovesAndCallsRepository()
    {
        _mockUserRepository.Setup(repo => repo.GetByUserNoAsync(
            It.IsAny<long>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            new User
            {
                UserId = 1,
                UserFName = "Test",
                UserLName = "Test",
                UserEmail = "Test",
                UserPassword = "Test",
                UserNo = 123456789
            });

        var testUser = new User
        {
            UserId = 1,
            UserFName = "Test1",
            UserLName = "Test1",
            UserEmail = "Test1",
            UserPassword= "Test1",
            UserStatus = UserStatus.working
        };

        await _userManager.UpdateUserAsync(testUser.UserNo, testUser, default);

        _mockUserRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<User>(s => s == testUser),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteUserAsync_WhenCalled_CallsRepository()
    {
        _mockUserRepository.Setup(repo => repo.GetByUserNoAsync(
          It.IsAny<long>(),
          It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User 
                {
                UserFName = "Test",
                UserLName = "Test",
                UserEmail = "Test",
                UserPassword = "Test",
                UserNo = 123456789
            }); 

        await _userManager.DeleteUserByUserNoAsync(123456789, default);

        _mockUserRepository
            .Verify(
            sr => sr.UpdateAsync(
                It.Is<User>(s => s.UserStatus == UserStatus.isdeleted),
                It.IsAny<CancellationToken>()), Times.Once);
    }

   
}