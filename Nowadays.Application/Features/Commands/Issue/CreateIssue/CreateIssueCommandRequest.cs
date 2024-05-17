using MediatR;

namespace Nowadays.Application.Features.Commands.Issue.CreateIssue
{
  public class CreateIssueCommandRequest : IRequest<CreateIssueCommandResponse>
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; } = DateTime.Now;
    public bool IsCompleted { get; set; } = false;
    public Guid ProjectId { get; set; }
  }
}
