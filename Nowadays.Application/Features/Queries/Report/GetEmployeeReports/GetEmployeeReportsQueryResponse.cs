using Nowadays.Application.DTOs.Report;

namespace Nowadays.Application.Features.Queries.Report.GetEmployeeReports
{
  public class GetEmployeeReportsQueryResponse
  {
    public IEnumerable<EmployeeReport> EmployeeReports { get; set; }
  }

}
