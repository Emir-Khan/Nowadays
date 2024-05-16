using Nowadays.Application.DTOs.Project;

namespace Nowadays.Application.Features.Queries.Project.GetProjects
{
  public class GetProjectsQueryResponse
  {
    public IEnumerable<ListProject> Projects { get; set; }
  }
}
