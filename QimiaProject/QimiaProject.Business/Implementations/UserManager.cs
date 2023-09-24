using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using QimiaProject.Business.Abstracts;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;
using System.Diagnostics;

namespace QimiaProject.Business.Implementations;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }
    public async Task<string> GetToken()
    {
        var tokenRequest = new ResourceOwnerTokenRequest
        {
            ClientId = "0939LwyYY5EngszXHFGiCUPfRbKlrvKA",
            ClientSecret = "VIEpCScrvWKlNN-lxGhjWdkYwAgV1Iy5JkY_PRpQZylIFC_Ryoa3fSzDYBQdbvdY",
            Audience = "https://qimiaproject/api",
            Username = "ali.can.dgru10@gmail.com",
            Password = "Aa123456789.",
            Scope = "openid profile"
        };
        var auth0client = new AuthenticationApiClient(new Uri("https://dev-nym2ls0hxfm84emc.us.auth0.com"));
        var tokenResponse =await auth0client.GetTokenAsync(tokenRequest);//SignupUserAsync
        await auth0client.SignupUserAsync(new SignupUserRequest());
        Debug.WriteLine(tokenResponse);
        return tokenResponse.AccessToken;

    }
    public Task CreateUserAsync(
        User user,
        CancellationToken cancellationToken)
    {
        var tokenRequest = new ResourceOwnerTokenRequest
        {
            ClientId = "0939LwyYY5EngszXHFGiCUPfRbKlrvKA",
            ClientSecret = "VIEpCScrvWKlNN-lxGhjWdkYwAgV1Iy5JkY_PRpQZylIFC_Ryoa3fSzDYBQdbvdY",
            Audience = "https://qimiaproject/api",
            Username = user.UserEmail,
            Password = user.UserPassword,
            Scope = "openid profile"
        };
        var signupRequest = new SignupUserRequest
        {
            Connection = "Username-Password-Authentication", 
            Email = user.UserEmail, 
            Password = user.UserPassword, 
        };
        var auth0client = new AuthenticationApiClient(new Uri("https://dev-nym2ls0hxfm84emc.us.auth0.com"));
        auth0client.SignupUserAsync(signupRequest);
        

        Random random = new Random();
        user.UserId = default;
        user.UserNo = random.Next(100000000, 999999999);
        user.UserStatus = UserStatus.working;

        return _userRepository.CreateAsync(user, cancellationToken);
    }

    public async Task<User> GetUserByUserNoAsync(
        long userno,
        CancellationToken cancellationToken)
    {
   
        var user = await _userRepository.GetByUserNoAsync(userno, cancellationToken);

        return user;
    }

    public async Task DeleteUserByUserNoAsync(
        long userno,
        CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByUserNoAsync(userno, cancellationToken);
        entity.UserStatus = UserStatus.isdeleted;
        await _userRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task UpdateUserAsync(
    long userNo,
    User user,
    CancellationToken cancellationToken)
    {
        var oldUser = await _userRepository.GetByUserNoAsync(userNo, cancellationToken);

        switch (oldUser.UserStatus)
        {
            case UserStatus.isdeleted:
                throw new Exception("Yanlış bilgi girildi. Kullanıcı durumu uygun değil.");
            default:
                await _userRepository.UpdateAsync(user, cancellationToken);
                break;
        }
    }
}
