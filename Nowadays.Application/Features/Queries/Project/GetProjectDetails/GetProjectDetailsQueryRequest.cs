using MediatR;

namespace Nowadays.Application.Features.Queries.Project.GetProjectDetails
{
  public class GetProjectDetailsQueryRequest : IRequest<ProjectDetailsQueryResponse>
  {
    public Guid? Id { get; set; }
  }

}
