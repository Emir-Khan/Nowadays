using MediatR;

namespace Nowadays.Application.Features.Queries.GetCompanyById
{
  public class GetCompanyByIdQueryRequest : IRequest<GetCompanyByIdQueryResponse>
  {
    public Guid Id { get; set; }
  }
}
