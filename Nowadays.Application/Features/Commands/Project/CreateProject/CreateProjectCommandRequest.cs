using MediatR;

namespace Nowadays.Application.Features.Commands.Project.CreateProject
{
  public class CreateProjectCommandRequest : IRequest<CreateProjectCommandResponse>
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Guid CompanyId { get; set; }
  }
}
