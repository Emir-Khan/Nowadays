using Nowadays.Application.DTOs.Report;

namespace Nowadays.Application.Abstractions.Services
{
  public interface IReportService
  {
    Task<IEnumerable<CompanyReport>> GetCompanyReportsAsync(Guid? id = null);
    Task<IEnumerable<ProjectReport>> GetProjectReportsAsync(Guid? id = null);
    Task<IEnumerable<EmployeeReport>> GetEmployeeReportsAsync(Guid? id = null);
    Task<IEnumerable<IssueReport>> GetIssueReportsAsync(Guid? id = null);
  }
}
