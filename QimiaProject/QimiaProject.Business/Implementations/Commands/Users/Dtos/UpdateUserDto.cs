using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Commands.Users.Dtos;

public class UpdateUserDto
{
    public string? UserFName { get; set; }
    public string? UserLName { get; set; }
    public UserStatus UserStatus { get; set; }
    
}
