using MediatR;

namespace Nowadays.Application.Features.Queries.Report.GetCompanyReports
{
  public class GetCompanyReportsQueryRequest : IRequest<GetCompanyReportsQueryResponse>
  {
    public Guid? Id { get; set; }
  }

}
