using Nowadays.Application.DTOs.Issue;

namespace Nowadays.Application.Features.Queries.Issue.GetIssues
{
  public class GetIssuesQueryResponse
  {
    public IEnumerable<ListIssue> Issues { get; set; }
  }
}
