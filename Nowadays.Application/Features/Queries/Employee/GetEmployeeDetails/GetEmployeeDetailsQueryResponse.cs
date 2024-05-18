using Nowadays.Application.ViewModels.Employee;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeDetails
{
  public class GetEmployeeDetailsQueryResponse
  {
    public IEnumerable<VM_Get_EmployeeDetails> Employees { get; set; }
  }
}
