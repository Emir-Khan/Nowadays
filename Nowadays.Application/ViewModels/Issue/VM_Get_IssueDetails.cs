using Nowadays.Application.DTOs.Employee;

namespace Nowadays.Application.ViewModels.Issue
{
  public class VM_Get_IssueDetails
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; }
    public IEnumerable<ListEmployee> Employees { get; set; }
  }
}
