using Nowadays.Application.DTOs.Issue;
using Nowadays.Application.DTOs.Project;

namespace Nowadays.Application.ViewModels.Employee
{
  public class VM_Get_EmployeeDetails
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string TCKN { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<ListProject> Projects { get; set; }
    public IEnumerable<ListIssue> Issues { get; set; }
  }
}
