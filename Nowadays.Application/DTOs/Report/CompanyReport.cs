namespace Nowadays.Application.DTOs.Report
{
  public class CompanyReport
  {
    public string Name { get; set; }
    public IEnumerable<ProjectReport> Projects { get; set; }
    public int TotalEmployees { get; set; }
  }
}
