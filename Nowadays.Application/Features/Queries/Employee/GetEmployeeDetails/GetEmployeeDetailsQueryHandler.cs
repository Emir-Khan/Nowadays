using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Issue;
using Nowadays.Application.DTOs.Project;
using Nowadays.Application.ViewModels.Employee;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeDetails
{
  public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQueryRequest, GetEmployeeDetailsQueryResponse>
  {
    private readonly IEmployeeService _employeeService;

    public GetEmployeeDetailsQueryHandler(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    public async Task<GetEmployeeDetailsQueryResponse> Handle(GetEmployeeDetailsQueryRequest request, CancellationToken cancellationToken)
    {
      var employees = await _employeeService.GetEmployeeDetailsAsync(request.Id);

      return new GetEmployeeDetailsQueryResponse()
      {
        Employees = employees.Select(e => new VM_Get_EmployeeDetails
        {
          Id = e.Id,
          Name = e.Name,
          Email = e.Email,
          TCKN = e.TCKN,
          BirthDate = e.BirthDate,
          Projects = e.Projects.Select(p => new ListProject
          {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            DueDate = p.DueDate,
            IsCompleted = p.IsCompleted,
            CompanyId = p.CompanyId
          }),
          Issues = e.Issues.Select(i => new ListIssue
          {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            DueDate = i.DueDate,
            IsCompleted = i.IsCompleted
          })
        })
      };
    }
  }
}
