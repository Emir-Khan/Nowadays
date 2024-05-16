using MediatR;

namespace Nowadays.Application.Features.Queries.Project.GetProjectById
{
  public class GetProjectByIdQueryRequest : IRequest<GetProjectByIdQueryResponse>
  {
    public Guid Id { get; set; }
  }
}
