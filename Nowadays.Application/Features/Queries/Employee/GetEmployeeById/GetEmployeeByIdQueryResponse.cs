namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeById
{
  public class GetEmployeeByIdQueryResponse
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string TCKN { get; set; }
  }
}
