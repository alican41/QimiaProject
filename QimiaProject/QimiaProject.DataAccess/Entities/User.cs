
namespace QimiaProject.DataAccess.Entities;

public class User
{
    public int UserId { get; set; }
    public string UserFName { get; set; } = string.Empty;

    public string UserLName { get; set; } = string.Empty;

    public UserStatus UserStatus { get; set; }
    

    public long UserNo { get; set; }

    public string UserEmail { get; set; } = string.Empty;

    public string UserPassword { get; set; } = string.Empty;




}
