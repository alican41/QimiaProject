using Auth0.AuthenticationApi;
using Microsoft.AspNetCore.Http;
using QimiaProject.Business.Abstracts;
using System.Diagnostics;

namespace QimiaProject.Business.Implementations;

public class AuthManager : IAuthManager
{
    private readonly IHttpContextAccessor _httpContext;
    private  AuthenticationApiClient _authenticationApiClient;
    public AuthManager(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
        _authenticationApiClient = new AuthenticationApiClient(new Uri("https://dev-nym2ls0hxfm84emc.us.auth0.com"));
    }
    public async Task<string> GetUserEmail()
    {
        try {
            var token = GetTokenFromHeader();

            var userInfo = await _authenticationApiClient.GetUserInfoAsync(token);
            var userEmail = userInfo.Email;
          
            return userEmail;

            
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        throw new Exception("No Email");
    }

    private string GetTokenFromHeader()
    {
        var authHeader = _httpContext.HttpContext.Request.Headers["Authorization"].ToString();

        if (authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length).Trim();
            return token;
        }

        throw new Exception("Invalid Authorization header");
    }
}
