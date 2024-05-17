namespace Nowadays.Application.Features.Queries.Issue.GetIssueById
{
  public class GetIssueByIdQueryResponse
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
  }
}
