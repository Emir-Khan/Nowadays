using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Issue.AssignEmployeeToIssue
{
  public class AssignEmployeeToIssueCommandHandler : IRequestHandler<AssignEmployeeToIssueCommandRequest, AssignEmployeeToIssueCommandResponse>
  {
    readonly IIssueService _issueService;

    public AssignEmployeeToIssueCommandHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<AssignEmployeeToIssueCommandResponse> Handle(AssignEmployeeToIssueCommandRequest request, CancellationToken cancellationToken)
    {
      await _issueService.AssignEmployeeAsync(request.IssueId, request.EmployeeId);
      return new AssignEmployeeToIssueCommandResponse();
    }
  }
}
