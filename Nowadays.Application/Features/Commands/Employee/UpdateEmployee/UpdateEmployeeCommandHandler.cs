using MediatR;
using Nowadays.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      var dbEmployee = await _employeeService.GetEmployeeByIdAsync(request.Id);
      request.Name ??= dbEmployee.Name;
      request.Surname ??= dbEmployee.Surname;
      request.Email ??= dbEmployee.Email;
      request.TCKN ??= dbEmployee.TCKN;

      var updatedEmployee = await _employeeService.UpdateEmployeeAsync(new Domain.Entities.Employee
      {
        Id = request.Id,
        Name = request.Name,
        Surname = request.Surname,
        Email = request.Email,
        TCKN = request.TCKN
      });
      return new UpdateEmployeeCommandResponse()
      {
        Id = updatedEmployee.Id,
        Name = updatedEmployee.Name,
        Surname = updatedEmployee.Surname,
        Email = updatedEmployee.Email,
        TCKN = updatedEmployee.TCKN
      };
    }
  }
}
