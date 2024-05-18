using Nowadays.Application.DTOs.Employee;
using Nowadays.Application.DTOs.Issue;

namespace Nowadays.Application.ViewModels.Project
{
  public class VM_Get_ProjectDetails
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public IEnumerable<ListEmployee> AssignedEmployees { get; set; }
    public IEnumerable<ListIssue> AssignedIssues { get; set; }
  }
}
