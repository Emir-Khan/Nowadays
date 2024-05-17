using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Issue.DeleteIssue
{
  public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommandRequest, DeleteIssueCommandResponse>
  {
    readonly IIssueService _issueService;

    public DeleteIssueCommandHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<DeleteIssueCommandResponse> Handle(DeleteIssueCommandRequest request, CancellationToken cancellationToken)
    {
      await _issueService.DeleteIssueAsync(request.Id);
      return new DeleteIssueCommandResponse();
    }
  }
}
