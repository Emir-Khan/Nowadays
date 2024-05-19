using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Employee.UpdateEmployee
{
  public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
  {
    readonly IEmployeeService _employeeService;

    public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
      var employee = await _employeeService.GetEmployeeByIdAsync(request.Id);
      employee.Name = request.Name ?? employee.Name;
      employee.Surname = request.Surname ?? employee.Surname;
      employee.Email = request.Email ?? employee.Email;
      employee.TCKN = request.TCKN ?? employee.TCKN;
      employee.BirthDate = request.BirthDate ?? employee.BirthDate;

      var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
      return new UpdateEmployeeCommandResponse()
      {
        Id = updatedEmployee.Id,
        Name = updatedEmployee.Name,
        Surname = updatedEmployee.Surname,
        Email = updatedEmployee.Email,
        TCKN = updatedEmployee.TCKN,
        BirthDate = updatedEmployee.BirthDate
      };
    }
  }
}
