using MediatR;

namespace Nowadays.Application.Features.Queries.Report.GetProjectReports
{
  public class GetProjectReportsQueryRequest : IRequest<GetProjectReportsQueryResponse>
  {
    public Guid? Id { get; set; }
  }

}
