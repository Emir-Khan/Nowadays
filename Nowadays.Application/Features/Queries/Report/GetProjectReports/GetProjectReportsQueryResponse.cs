using Nowadays.Application.DTOs.Report;

namespace Nowadays.Application.Features.Queries.Report.GetProjectReports
{
  public class GetProjectReportsQueryResponse
  {
    public IEnumerable<ProjectReport> ProjectReports { get; set; }
  }

}
