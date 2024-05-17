using MediatR;
using Nowadays.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeById
{
  public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQueryRequest, GetEmployeeByIdQueryResponse>
  {
    readonly IEmployeeService _employeeService;

    public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
    {
      var employee = await _employeeService.GetEmployeeByIdAsync(request.Id);
      return new GetEmployeeByIdQueryResponse
      {
        Id = employee.Id,
        Name = employee.Name,
        Surname = employee.Surname,
        Email = employee.Email,
        TCKN = employee.TCKN
      };
    }
  }
}
