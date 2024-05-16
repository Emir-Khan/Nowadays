using Nowadays.Domain.Entities.Common;

namespace Nowadays.Domain.Entities
{
  public class Issue : BaseEntity
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Guid ProjectId { get; set; }

    public Project Project { get; set; }
    public ICollection<Employee> Employees { get; set; }
  }
}
