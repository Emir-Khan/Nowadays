using MediatR;

namespace Nowadays.Application.Features.Queries.Report.GetIssueReports
{
  public class GetIssueReportsQueryRequest : IRequest<GetIssueReportsQueryResponse>
  {
    public Guid? Id { get; set; }
  }

}
