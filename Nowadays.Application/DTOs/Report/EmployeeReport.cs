namespace Nowadays.Application.DTOs.Report
{
  public class EmployeeReport
  {
    public string Name { get; set; }
    public int AssignedProjects { get; set; }
    public int CompletedProjects { get; set; }
    public int OpenProjects { get; set; }
    public IssueReport IssueReport { get; set; }
  }
}
