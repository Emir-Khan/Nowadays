using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Project.AssignEmployee
{
  public class AssignEmployeeToProjectCommandHandler : IRequestHandler<AssignEmployeeToProjectCommandRequest, AssignEmployeeToProjectCommandResponse>
  {
    readonly IProjectService _projectService;

    public AssignEmployeeToProjectCommandHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<AssignEmployeeToProjectCommandResponse> Handle(AssignEmployeeToProjectCommandRequest request, CancellationToken cancellationToken)
    {
      await _projectService.AssignEmployeeAsync(request.ProjectId, request.EmployeeId);
      return new AssignEmployeeToProjectCommandResponse();
    }
  }
}
