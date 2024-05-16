namespace Nowadays.Application.Features.Commands.Project.CreateProject
{
  public class CreateProjectCommandResponse
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Guid CompanyId { get; set; }
  }
}
