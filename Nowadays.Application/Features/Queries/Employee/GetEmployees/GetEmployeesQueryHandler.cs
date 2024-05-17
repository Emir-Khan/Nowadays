using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployees
{
  public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQueryRequest, GetEmployeesQueryResponse>
  {
    readonly IEmployeeService _employeeService;

    public GetEmployeesQueryHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<GetEmployeesQueryResponse> Handle(GetEmployeesQueryRequest request, CancellationToken cancellationToken)
    {
      var employees = await _employeeService.GetEmployeesAsync();
      return new GetEmployeesQueryResponse
      {
        Employees = employees.Select(e => new ListEmployee
        {
          Id = e.Id,
          Name = e.Name,
          Surname = e.Surname,
          Email = e.Email,
          TCKN = e.TCKN
        })
      };
    }
  }
}
