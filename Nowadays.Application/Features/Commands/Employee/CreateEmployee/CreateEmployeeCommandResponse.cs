namespace Nowadays.Application.Features.Commands.Employee.CreateEmployee
{
  public class CreateEmployeeCommandResponse
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string TCKN { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
