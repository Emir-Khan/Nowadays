using MediatR;

namespace Nowadays.Application.Features.Queries.Employee.GetEmployeeById
{
  public class GetEmployeeByIdQueryRequest : IRequest<GetEmployeeByIdQueryResponse>
  {
    public Guid Id { get; set; }
  }
}
