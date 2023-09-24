using QimiaProject.Business.Abstracts;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.Business.Implementations;

public class RequestManager : IRequestManager
{
    private readonly IRequestRepository _requestRepository;

    public RequestManager(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken)
    {
        return _requestRepository.GetAllAsync(cancellationToken);
    }

    public Task CreateRequestAsync(
        Request request,
        CancellationToken cancellationToken) 
    {
        request.RequestId = default;
        request.RequestStatus = RequestStatus.pending;
        //booklar arasında isdeleted rezerveyse alma 
        return _requestRepository.CreateAsync(request, cancellationToken);
    }

    public async Task<Request> GetRequestByIdAsync(
        int requestId,
        CancellationToken cancellationToken)
    {
        var request = await _requestRepository.GetByIdAsync(requestId, cancellationToken);

        return request;
    }

    public async Task DeleteRequestByIdAsync(
        int requestId,
        CancellationToken cancellationToken)
    {
        var entity = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        entity.RequestStatus = RequestStatus.isdeleted;
        await _requestRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task UpdateRequestAsync(
        int requestId,
        Request request,
        CancellationToken cancellationToken)
    {
        var oldRequest = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        switch (oldRequest.RequestStatus)
        {
            case RequestStatus.isdeleted:
                throw new Exception("Yanlış bilgi girildi. İstek durumu uygun değil.");
            default:
                await _requestRepository.UpdateAsync(request, cancellationToken);
                break;

        }
    }
}
