namespace Nowadays.Application.DTOs.Report
{
  public class ProjectReport
  {
    public string Title { get; set; }
    public int AssignedEmployeeNumber { get; set; }
    public IssueReport IssueReport { get; set; }
  }
}
