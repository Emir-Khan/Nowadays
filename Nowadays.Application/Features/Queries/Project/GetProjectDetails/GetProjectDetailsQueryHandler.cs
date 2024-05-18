using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Employee;
using Nowadays.Application.DTOs.Issue;
using Nowadays.Application.ViewModels.Project;

namespace Nowadays.Application.Features.Queries.Project.GetProjectDetails
{
  public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQueryRequest, ProjectDetailsQueryResponse>
  {
    readonly IProjectService _projectService;

    public GetProjectDetailsQueryHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<ProjectDetailsQueryResponse> Handle(GetProjectDetailsQueryRequest request, CancellationToken cancellationToken)
    {
      var projects = await _projectService.GetProjectDetailsAsync(request.Id);

      var projectDetails = projects.Select(p => new VM_Get_ProjectDetails
      {
        Id = p.Id,
        Title = p.Title,
        Description = p.Description,
        CompanyName = p.Company.Name,
        IsCompleted = p.IsCompleted,
        DueDate = p.DueDate,
        AssignedEmployees = p.Employees.Select(e => new ListEmployee
        {
          Id = e.Id,
          Email = e.Email,
          Name = e.Name,
          Surname = e.Surname,
          TCKN = e.TCKN
        }).ToList(),
        AssignedIssues = p.Issues.Select(i => new ListIssue
        {
          Id = i.Id,
          Title = i.Title,
          Description = i.Description,
          IsCompleted = i.IsCompleted
        }).ToList()
      });

      return new ProjectDetailsQueryResponse()
      {
        Projects = projectDetails
      };
    }
  }
}
