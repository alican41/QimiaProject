using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QimiaProject.Business.Implementations.Commands.Users.Dtos;

namespace QimiaProject.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    public static string UserTokenEmail="";
    public static string UserTokenPassword = "";
    [HttpPost("get-token")]
    public async Task<IActionResult> GetToken(
            [FromBody] CreateTokenDto token)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                
                string auth0TokenEndpoint = "https://dev-nym2ls0hxfm84emc.us.auth0.com/oauth/token";

               
                var tokenRequest = new
                {
                    client_id = "0939LwyYY5EngszXHFGiCUPfRbKlrvKA",
                    client_secret = "VIEpCScrvWKlNN-lxGhjWdkYwAgV1Iy5JkY_PRpQZylIFC_Ryoa3fSzDYBQdbvdY",
                    audience = "https://qimiaproject/api",
                    grant_type = "password",
                    username = token.UserEmail,
                    password = token.UserPassword,
                    scope = "openid"
                };

               
                var response = await httpClient.PostAsJsonAsync(auth0TokenEndpoint, tokenRequest);

          
                if (response.IsSuccessStatusCode)
                {
                   
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    UserTokenEmail = token.UserEmail ?? string.Empty;
                    UserTokenPassword = token.UserPassword ?? string.Empty;
                    return Ok(tokenResponse);
                }
                else
                {
                  
                    return StatusCode((int)response.StatusCode,
                        "Kullanıcıya ait token bulunamadı." +
                        " Lütfen önce Adminden kullanıcı oluşturmasını isteyin.");
                }
            }
        }
        catch (Exception ex)
        {
           
            return BadRequest("Token alınamadı: " + ex.Message);
        }
    }
}

