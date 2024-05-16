namespace Nowadays.Application.Features.Commands.Project.UpdateProject
{
  public class UpdateProjectCommandResponse
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public Guid CompanyId { get; set; }
  }
}
