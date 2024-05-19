using MediatR;

namespace Nowadays.Application.Features.Commands.Employee.CreateEmployee
{
  public class CreateEmployeeCommandRequest : IRequest<CreateEmployeeCommandResponse>
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string TCKN { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
