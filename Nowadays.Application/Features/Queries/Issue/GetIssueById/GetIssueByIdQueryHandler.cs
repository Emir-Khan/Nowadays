using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Issue.GetIssueById
{
  public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQueryRequest, GetIssueByIdQueryResponse>
  {
    readonly IIssueService _issueService;

    public GetIssueByIdQueryHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<GetIssueByIdQueryResponse> Handle(GetIssueByIdQueryRequest request, CancellationToken cancellationToken)
    {
      var issue = await _issueService.GetIssueByIdAsync(request.Id);
      return new GetIssueByIdQueryResponse
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
