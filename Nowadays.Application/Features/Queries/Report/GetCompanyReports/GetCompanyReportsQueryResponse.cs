using Nowadays.Application.DTOs.Report;

namespace Nowadays.Application.Features.Queries.Report.GetCompanyReports
{
  public class GetCompanyReportsQueryResponse
  {
    public IEnumerable<CompanyReport> CompanyReports { get; set; }
  }

}
