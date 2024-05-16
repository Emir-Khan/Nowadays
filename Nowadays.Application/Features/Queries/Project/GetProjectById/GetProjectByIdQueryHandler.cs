using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Project.GetProjectById
{
  public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryRequest, GetProjectByIdQueryResponse>
  {
    readonly IProjectService _projectService;

    public GetProjectByIdQueryHandler(IProjectService projectService)
    {
      _projectService = projectService;
    }

    public async Task<GetProjectByIdQueryResponse> Handle(GetProjectByIdQueryRequest request, CancellationToken cancellationToken)
    {
      var project = await _projectService.GetByIdAsync(request.Id);

      return new GetProjectByIdQueryResponse
      {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
        DueDate = project.DueDate,
        IsCompleted = project.IsCompleted,
        CompanyId = project.CompanyId
      };
    }
  }
}
