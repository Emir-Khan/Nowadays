using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Issue;

namespace Nowadays.Application.Features.Queries.Issue.GetIssues
{
  public class GetIssuesQueryHandler: IRequestHandler<GetIssuesQueryRequest, GetIssuesQueryResponse>
  {
    readonly IIssueService _issueService;

    public GetIssuesQueryHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<GetIssuesQueryResponse> Handle(GetIssuesQueryRequest request, CancellationToken cancellationToken)
    {
      var issues = await _issueService.GetIssuesAsync();
      return new GetIssuesQueryResponse
      {
        Issues = issues.Select(i => new ListIssue
        {
          Id = i.Id,
          Title = i.Title,
          Description = i.Description,
          DueDate = i.DueDate,
          IsCompleted = i.IsCompleted
        })
      };
    }
  }
}
