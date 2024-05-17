using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Employee.DeleteEmployee
{
  public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
  {
    readonly IEmployeeService _employeeService;

    public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
      await _employeeService.DeleteEmployeeAsync(request.Id);
      return new DeleteEmployeeCommandResponse();
    }
  }
}
