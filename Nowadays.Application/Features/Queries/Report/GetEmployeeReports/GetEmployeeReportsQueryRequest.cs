using MediatR;

namespace Nowadays.Application.Features.Queries.Report.GetEmployeeReports
{
  public class GetEmployeeReportsQueryRequest : IRequest<GetEmployeeReportsQueryResponse>
  {
    public Guid? Id { get; set; }
  }

}
