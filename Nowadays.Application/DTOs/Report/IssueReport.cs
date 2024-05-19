namespace Nowadays.Application.DTOs.Report
{
  public class IssueReport
  {
    public int CompletedIssues { get; set; }
    public int OpenIssues { get; set; }
    public int TotalIssues { get; set; }
    public int ExpiredIssues { get; set; }
  }
}
