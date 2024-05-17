using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Issue.CreateIssue
{
  public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommandRequest, CreateIssueCommandResponse>
  {
    readonly IIssueService _issueService;

    public CreateIssueCommandHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<CreateIssueCommandResponse> Handle(CreateIssueCommandRequest request, CancellationToken cancellationToken)
    {
      var issue = await _issueService.CreateIssueAsync(new Domain.Entities.Issue
      {
        Title = request.Title,
        Description = request.Description,
        DueDate = request.DueDate,
        IsCompleted = request.IsCompleted,
        ProjectId = request.ProjectId
      });
      return new CreateIssueCommandResponse()
      {
        Id = issue.Id,
        Title = issue.Title,
        Description = issue.Description,
        DueDate = issue.DueDate,
        IsCompleted = issue.IsCompleted
      };
    }
  }
}
