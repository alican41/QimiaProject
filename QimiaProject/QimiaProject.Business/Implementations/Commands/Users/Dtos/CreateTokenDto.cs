namespace QimiaProject.Business.Implementations.Commands.Users.Dtos;

public class CreateTokenDto
{
    public string? UserEmail { get; set; }
    public string? UserPassword { get; set; }
}
