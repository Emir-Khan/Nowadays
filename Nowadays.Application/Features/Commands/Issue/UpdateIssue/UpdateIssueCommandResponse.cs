namespace Nowadays.Application.Features.Commands.Issue.UpdateIssue
{
  public class UpdateIssueCommandResponse
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
  }
}
