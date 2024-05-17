namespace Nowadays.Application.Features.Commands.Issue.CreateIssue
{
  public class CreateIssueCommandResponse
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
  }
}
