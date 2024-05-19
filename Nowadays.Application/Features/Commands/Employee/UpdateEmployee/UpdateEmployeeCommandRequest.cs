using MediatR;

namespace Nowadays.Application.Features.Commands.Employee.UpdateEmployee
{
  public class UpdateEmployeeCommandRequest : IRequest<UpdateEmployeeCommandResponse>
  {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? TCKN { get; set; }
    public DateTime? BirthDate { get; set; }
  }
}
