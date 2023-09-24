
namespace QimiaProject.Business.Abstracts;

public interface IAuthManager
{
    public Task<string> GetUserEmail();
}
