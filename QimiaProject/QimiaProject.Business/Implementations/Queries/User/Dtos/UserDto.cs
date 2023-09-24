
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Queries.User.Dtos;

public class UserDto
{
    public int UserId { get; set; }

    public string? UserFName { get; set; }

    public string? UserLName { get; set; }

    public UserStatus UserStatus { get; set; }

    public long? UserNo { get; set; }

    public string? UserEmail { get; set;}

    public string? UserPassword { get; set; }
}
