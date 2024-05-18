using MediatR;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeDetails
{
  public class GetEmployeeDetailsQueryRequest : IRequest<GetEmployeeDetailsQueryResponse>
  {
    public Guid? Id { get; set; }
  }
}
