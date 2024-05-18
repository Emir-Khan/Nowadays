using MediatR;

namespace Nowadays.Application.Features.Queries.Company.GetCompanyDetails
{
  public class GetCompanyDetailsQueryRequest : IRequest<GetCompanyDetailsResponse>
  {
    public Guid? Id { get; set; }
  }
}
