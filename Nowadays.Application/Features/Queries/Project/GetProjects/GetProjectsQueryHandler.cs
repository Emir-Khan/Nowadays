using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.Application.Features.Queries.Project.GetProjects
{
  public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQueryRequest, GetProjectsQueryResponse>
  {
    readonly IProjectService _projectService;

    public GetProjectsQueryHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<GetProjectsQueryResponse> Handle(GetProjectsQueryRequest request, CancellationToken cancellationToken)
    {
      var projects = await _projectService.GetAllAsync();

      return new GetProjectsQueryResponse
      {
        Projects = projects.Select(p => new ListProject
        {
          Id = p.Id,
          Title = p.Title,
          Description = p.Description,
          DueDate = p.DueDate,
          IsCompleted = p.IsCompleted,
          CompanyId = p.CompanyId
        })
      };
    }
  }
}
