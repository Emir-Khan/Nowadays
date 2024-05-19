using Microsoft.EntityFrameworkCore;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Report;
using Nowadays.Application.Repositories;

namespace Nowadays.Persistence.Services
{
  public class ReportService : IReportService
  {
    readonly ICompanyReadRepository _companyReadRepository;
    readonly IProjectReadRepository _projectReadRepository;
    readonly IEmployeeReadRepository _employeeReadRepository;
    readonly IIssueReadRepository _issueReadRepository;

    public ReportService(ICompanyReadRepository companyReadRepository, IProjectReadRepository projectReadRepository, IEmployeeReadRepository employeeReadRepository, IIssueReadRepository issueReadRepository)
    {
      _companyReadRepository = companyReadRepository;
      _projectReadRepository = projectReadRepository;
      _employeeReadRepository = employeeReadRepository;
      _issueReadRepository = issueReadRepository;
    }

    public async Task<IEnumerable<CompanyReport>> GetCompanyReportsAsync(Guid? id = null)
    {
      var query = _companyReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(x => x.Id == id);

      var companies = await query.Include(c => c.Projects)
                        .ThenInclude(p => p.Employees)
                      .Include(c => c.Projects)
                        .ThenInclude(p => p.Issues)
                        .ToListAsync();

      var companyReports = companies.Select(x => new CompanyReport
      {
        Name = x.Name,
        TotalEmployees = x.Projects.SelectMany(p => p.Employees).Distinct().Count(),
        Projects = x.Projects.Select(p =>
        new ProjectReport
        {
          Title = p.Title,
          AssignedEmployeeNumber = p.Employees.Count,
          IssueReport = new IssueReport
          {
            TotalIssues = p.Issues.Count,
            CompletedIssues = p.Issues.Count(i => i.IsCompleted),
            OpenIssues = p.Issues.Count(i => !i.IsCompleted && i.DueDate > DateTime.UtcNow),
            ExpiredIssues = p.Issues.Count(i => !i.IsCompleted && i.DueDate < DateTime.UtcNow)
          }
        })
      });

      return companyReports;
    }

    public async Task<IEnumerable<EmployeeReport>> GetEmployeeReportsAsync(Guid? id = null)
    {
      var query = _employeeReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(x => x.Id == id);

      var employees = await query.Include(e => e.Projects)
                        .ThenInclude(p => p.Issues)
                      .ToListAsync();

      var employeeReports = employees.Select(x => new EmployeeReport
      {
        Name = x.Name,
        AssignedProjects = x.Projects.Count,
        CompletedProjects = x.Projects.Count(p => p.IsCompleted),
        OpenProjects = x.Projects.Count(p => !p.IsCompleted),
        IssueReport = new IssueReport
        {
          TotalIssues = x.Projects.SelectMany(p => p.Issues).Count(),
          CompletedIssues = x.Projects.SelectMany(p => p.Issues).Count(i => i.IsCompleted),
          OpenIssues = x.Projects.SelectMany(p => p.Issues).Count(i => !i.IsCompleted && i.DueDate > DateTime.UtcNow),
          ExpiredIssues = x.Projects.SelectMany(p => p.Issues).Count(i => !i.IsCompleted && i.DueDate < DateTime.UtcNow)
        }
      });

      return employeeReports;
    }

    public async Task<IEnumerable<IssueReport>> GetIssueReportsAsync(Guid? id = null)
    {
      var query = _issueReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(x => x.Id == id);

      var issues = await query.ToListAsync();

      var issueReports = issues.Select(x => new IssueReport
      {
        TotalIssues = issues.Count,
        CompletedIssues = issues.Count(i => i.IsCompleted),
        OpenIssues = issues.Count(i => !i.IsCompleted && i.DueDate > DateTime.UtcNow),
        ExpiredIssues = issues.Count(i => !i.IsCompleted && i.DueDate < DateTime.UtcNow)
      });

      return issueReports;
    }

    public async Task<IEnumerable<ProjectReport>> GetProjectReportsAsync(Guid? id = null)
    {
      var query = _projectReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(x => x.Id == id);

      var projects = await query.Include(p => p.Employees)
                        .Include(e => e.Issues)
                        .ToListAsync();

      var projectReports = projects.Select(x => new ProjectReport
      {
        Title = x.Title,
        AssignedEmployeeNumber = x.Employees.Count,
        IssueReport = new IssueReport
        {
          TotalIssues = x.Issues.Count,
          CompletedIssues = x.Issues.Count(i => i.IsCompleted),
          OpenIssues = x.Issues.Count(i => !i.IsCompleted && i.DueDate > DateTime.UtcNow),
          ExpiredIssues = x.Issues.Count(i => !i.IsCompleted && i.DueDate < DateTime.UtcNow)
        }
      });

      return projectReports;
    }
  }
}
