using MediatR;

namespace Nowadays.Application.Features.Commands.Issue.DeleteIssue
{
  public class DeleteIssueCommandRequest : IRequest<DeleteIssueCommandResponse>
  {
    public Guid Id { get; set; }
  }
}
