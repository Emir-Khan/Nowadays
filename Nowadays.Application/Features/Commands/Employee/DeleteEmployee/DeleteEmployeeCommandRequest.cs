using MediatR;

namespace Nowadays.Application.Features.Commands.Employee.DeleteEmployee
{
  public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
  {
    public Guid Id { get; set; }
  }
}
