using MediatR;

namespace Nowadays.Application.Features.Commands.Issue.AssignEmployeeToIssue
{
  public class AssignEmployeeToIssueCommandRequest : IRequest<AssignEmployeeToIssueCommandResponse>
  {
    public Guid IssueId { get; set; }
    public Guid EmployeeId { get; set; }
  }

}
