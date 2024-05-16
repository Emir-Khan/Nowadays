using Nowadays.Application.DTOs;

namespace Nowadays.Application.Features.Queries.GetCompanies
{
  public class GetCompaniesQueryResponse
  {
    public required List<ListCompany> Companies { get; set; }
  }
}
