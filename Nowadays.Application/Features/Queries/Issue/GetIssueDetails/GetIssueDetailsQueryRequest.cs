using MediatR;

namespace Nowadays.Application.Features.Queries.Issue.GetIssueDetails
{
  public class GetIssueDetailsQueryRequest : IRequest<GetIssueDetailsQueryResponse>
  {
    public Guid? Id { get; set; }
  }
}
