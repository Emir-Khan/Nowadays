using Nowadays.Domain.Entities;

namespace Nowadays.Application.Abstractions.Services
{
  public interface IIssueService
  {
    Task<IEnumerable<Issue>> GetIssuesAsync();
    Task<Issue> GetIssueByIdAsync(Guid id);
    Task<Issue> CreateIssueAsync(Issue issue);
    Task<Issue> UpdateIssueAsync(Issue issue);
    Task DeleteIssueAsync(Guid id);
  }
}
