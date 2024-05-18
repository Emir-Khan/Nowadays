using Nowadays.Application.DTOs.Project;

namespace Nowadays.Application.ViewModels.Company
{
  public class VM_Get_CompanyDetails
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public ICollection<ListProject> Projects { get; set; }
  }
}
