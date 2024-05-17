using Nowadays.Application.DTOs.Employee;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployees
{
  public class GetEmployeesQueryResponse
  {
    public IEnumerable<ListEmployee> Employees { get; set; }
  }
}
