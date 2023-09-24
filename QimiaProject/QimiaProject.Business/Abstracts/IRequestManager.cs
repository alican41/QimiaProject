using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Abstracts;

public interface IRequestManager
{
    public Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken);

    public Task CreateRequestAsync(
        Request request,
        CancellationToken cancellationToken);

    public Task<Request> GetRequestByIdAsync(
        int requestId,
        CancellationToken cancellationToken);

    public Task DeleteRequestByIdAsync(
        int requestId,
        CancellationToken cancellationToken);

    public Task UpdateRequestAsync(
        int requestId,
        Request request,
        CancellationToken cancellationToken);
}
