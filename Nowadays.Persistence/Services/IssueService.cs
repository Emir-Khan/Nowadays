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
    readonly IProjectReadRepository _projectReadRepository;


    public IssueService(IIssueReadRepository issueReadRepository, IIssueWriteRepository issueWriteRepository, IProjectReadRepository employeeReadRepository)
    {
      _issueReadRepository = issueReadRepository;
      _issueWriteRepository = issueWriteRepository;
      _projectReadRepository = employeeReadRepository;
    }

    public async Task AssignEmployeeAsync(Guid issueId, Guid employeeId)
    {
      var issue = await _issueReadRepository.GetByIdAsync(issueId.ToString());
      var employee = await _projectReadRepository.Table.Include(p => p.Employees.Where(e => e.Id == employeeId))
        .SelectMany(p => p.Employees)
        .FirstOrDefaultAsync() ?? throw new Exception("This employee is not assigned to the issue's project or employee not found. ");

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

    public async Task<IEnumerable<Issue>> GetIssueDetailsAsync(Guid? id = null)
    {
      IQueryable<Issue> query = _issueReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(i => i.Id == id);

      return await query.Include(i => i.Employees).Include(i => i.Project).ToListAsync();
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
