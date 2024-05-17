using Microsoft.EntityFrameworkCore;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;

namespace Nowadays.Persistence.Services
{
  public class IssueService : IIssueService
  {
    readonly IIssueReadRepository _issueReadRepository;
    readonly IIssueWriteRepository _issueWriteRepository;
    readonly IEmployeeReadRepository _employeeReadRepository;

    public IssueService(IIssueReadRepository issueReadRepository, IIssueWriteRepository issueWriteRepository, IEmployeeReadRepository employeeReadRepository)
    {
      _issueReadRepository = issueReadRepository;
      _issueWriteRepository = issueWriteRepository;
      _employeeReadRepository = employeeReadRepository;
    }

    public async Task AssignEmployeeAsync(Guid issueId, Guid employeeId)
    {
      var issue = await _issueReadRepository.GetByIdAsync(issueId.ToString());
      var employee = await _employeeReadRepository.Table.Where(e => e.Id == employeeId)
        .Include(e => e.Projects)
        .FirstOrDefaultAsync() ?? throw new Exception("Employee not found");

      issue.Employees = [employee];
      _issueWriteRepository.Update(issue);

      await _issueWriteRepository.SaveAsync();
    }

    public async Task<Issue> CreateIssueAsync(Issue issue)
    {
      await _issueWriteRepository.AddAsync(issue);
      await _issueWriteRepository.SaveAsync();
      return issue;
    }

    public async Task DeleteIssueAsync(Guid id)
    {
      await _issueWriteRepository.RemoveAsync(id.ToString());
      await _issueWriteRepository.SaveAsync();
    }

    public async Task<Issue> GetIssueByIdAsync(Guid id)
    {
      return await _issueReadRepository.GetByIdAsync(id.ToString(), false);
    }

    public async Task<IEnumerable<Issue>> GetIssuesAsync()
    {
      return await _issueReadRepository.GetAll(false).ToListAsync();
    }

    public async Task<Issue> UpdateIssueAsync(Issue issue)
    {
      _issueWriteRepository.Update(issue);
      await _issueWriteRepository.SaveAsync();
      return issue;
    }
  }
}
