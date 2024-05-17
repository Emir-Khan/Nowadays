using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Issue.UpdateIssue
{
  public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommandRequest, UpdateIssueCommandResponse>
  {
    readonly IIssueService _issueService;

    public UpdateIssueCommandHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<UpdateIssueCommandResponse> Handle(UpdateIssueCommandRequest request, CancellationToken cancellationToken)
    {
      var dbIssue = await _issueService.GetIssueByIdAsync(request.Id);
      request.Title ??= dbIssue.Title;
      request.Description ??= dbIssue.Description;
      request.DueDate ??= dbIssue.DueDate;
      request.IsCompleted ??= dbIssue.IsCompleted;

      var updatedIssue = await _issueService.UpdateIssueAsync(new Domain.Entities.Issue
      {
        Id = request.Id,
        Title = request.Title,
        Description = request.Description,
        DueDate = (DateTime)request.DueDate,
        IsCompleted = (bool)request.IsCompleted
      });
      return new UpdateIssueCommandResponse()
      {
        Id = updatedIssue.Id,
        Title = updatedIssue.Title,
        Description = updatedIssue.Description,
        DueDate = updatedIssue.DueDate,
        IsCompleted = updatedIssue.IsCompleted
      };
    }
  }
}
