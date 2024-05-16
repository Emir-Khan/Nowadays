using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Project.CreateProject
{
  public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandRequest, CreateProjectCommandResponse>
  {
    readonly IProjectService _projectService;

    public CreateProjectCommandHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
    {
      var project = new Domain.Entities.Project
      {
        Title = request.Title,
        Description = request.Description,
        DueDate = request.DueDate,
        IsCompleted = request.IsCompleted,
        CompanyId = request.CompanyId
      };

      var createdProject = await _projectService.CreateAsync(project);

      return new CreateProjectCommandResponse
      {
        Id = createdProject.Id,
        Title = createdProject.Title,
        Description = createdProject.Description,
        DueDate = createdProject.DueDate,
        CompanyId = createdProject.CompanyId
      };
    }

  }
}
