using Nowadays.Domain.Entities.Common;

namespace Nowadays.Domain.Entities
{
  public class Project : BaseEntity
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Guid CompanyId { get; set; }


    public Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Issue> Issues { get; set; }
  }
}
