using Nowadays.Domain.Entities;

namespace Nowadays.Application.Abstractions.Services
{
  public interface IIssueService
  {
    Task<IEnumerable<Issue>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(Guid id);
    Task<IEnumerable<Issue>> GetIssueDetailsAsync(Guid? id = null);
    Task<Issue> CreateIssueAsync(Issue issue);
    Task<Issue> UpdateIssueAsync(Issue issue);
    Task DeleteIssueAsync(Guid id);
    Task AssignEmployeeAsync(Guid issueId, Guid employeeId);
  }
}
