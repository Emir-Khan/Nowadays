using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Project.DeleteProject
{
  public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommandRequest, DeleteProjectCommandResponse>
  {
    readonly IProjectService _projectService;

    public DeleteProjectCommandHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<DeleteProjectCommandResponse> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
    {
      await _projectService.DeleteAsync(request.Id);

      return new DeleteProjectCommandResponse();
    }
  }

  public class DeleteProjectCommandRequest : IRequest<DeleteProjectCommandResponse>
  {
    public Guid Id { get; set; }
  }

  public class DeleteProjectCommandResponse
  {
  }
}
