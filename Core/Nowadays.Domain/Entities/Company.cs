using Nowadays.Domain.Entities.Common;

namespace Nowadays.Domain.Entities
{
  public class Company : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public ICollection<Project> Projects { get; set; }
  }
}
