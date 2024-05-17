using MediatR;

namespace Nowadays.Application.Features.Commands.Project.AssignEmployee
{
  public class AssignEmployeeToProjectCommandRequest : IRequest<AssignEmployeeToProjectCommandResponse>
  {
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
  }

}
