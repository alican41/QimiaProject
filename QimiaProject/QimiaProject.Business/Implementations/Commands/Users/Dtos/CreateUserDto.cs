namespace QimiaProject.Business.Implementations.Commands.Users.Dtos;

public class CreateUserDto
{
    public string? UserFName { get; set; }
    public string? UserLName { get; set; }
    public string? UserEmail { get; set;}
    public string? UserPassword { get; set; }

   //create yapılan user ın user no su ve userstatusu otomatik atanacak


}
