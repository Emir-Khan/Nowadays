using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Project.UpdateProject
{
  public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandRequest, UpdateProjectCommandResponse>
  {
    readonly IProjectService _projectService;

    public UpdateProjectCommandHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<UpdateProjectCommandResponse> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
    {
      var dbProject = await _projectService.GetByIdAsync(request.Id);

      var project = new Domain.Entities.Project
      {
        Id = request.Id,
        Title = request.Title ?? dbProject.Title,
        Description = request.Description ?? dbProject.Description,
        DueDate = request.DueDate ?? dbProject.DueDate,
        IsCompleted = request.IsCompleted ?? dbProject.IsCompleted,
        CompanyId = request.CompanyId ?? dbProject.CompanyId
      };

      var updatedProject = await _projectService.UpdateAsync(project);

      return new UpdateProjectCommandResponse
      {
        Id = updatedProject.Id,
        Title = updatedProject.Title,
        Description = updatedProject.Description,
        DueDate = updatedProject.DueDate,
        IsCompleted = updatedProject.IsCompleted,
        CompanyId = updatedProject.CompanyId
      };
    }
  }
}
