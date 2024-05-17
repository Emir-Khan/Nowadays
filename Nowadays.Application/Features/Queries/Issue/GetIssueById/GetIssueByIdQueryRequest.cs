using MediatR;

namespace Nowadays.Application.Features.Queries.Issue.GetIssueById
{
  public class GetIssueByIdQueryRequest : IRequest<GetIssueByIdQueryResponse>
  {
    public Guid Id { get; set; }
  }
}
