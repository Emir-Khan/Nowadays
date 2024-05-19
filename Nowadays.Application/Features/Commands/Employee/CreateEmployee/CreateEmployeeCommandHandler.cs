using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Employee.CreateEmployee
{
  public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
  {
    readonly IEmployeeService _employeeService;

    public CreateEmployeeCommandHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
      var employee = await _employeeService.CreateEmployeeAsync(new Domain.Entities.Employee
      {
        Name = request.Name,
        Surname = request.Surname,
        Email = request.Email,
        TCKN = request.TCKN,
        BirthDate = request.BirthDate
      });
      return new CreateEmployeeCommandResponse()
      {
        Id = employee.Id,
        Name = employee.Name,
        Surname = employee.Surname,
        Email = employee.Email,
        TCKN = employee.TCKN,
        BirthDate = employee.BirthDate
      };
    }
  }
}
