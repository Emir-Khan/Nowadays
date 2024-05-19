using Nowadays.Domain.Entities.Common;

namespace Nowadays.Domain.Entities
{
  public class Employee : BaseEntity
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string TCKN { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<Project> Projects { get; set; }
    public ICollection<Issue> Issues { get; set; }
  }
}
