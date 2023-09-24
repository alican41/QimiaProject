using MediatR;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations.Commands.Requests;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.Handlers.Requests.Commands;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
{
    private readonly IRequestManager _requestManager;

    public CreateRequestCommandHandler(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public async Task<int> Handle(CreateRequestCommand requestt , CancellationToken cancellationToken)
    {
        var request = new Request
        {
            UserNo = requestt.Request.UserNo,
            BookName = requestt.Request.BookName ?? string.Empty,
            BookAuthor = requestt.Request.BookAuthor ?? string.Empty,

        };

        await _requestManager.CreateRequestAsync(request, cancellationToken);

        return request.RequestId;
    }


}
