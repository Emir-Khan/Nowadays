using Nowadays.Application.DTOs;

namespace Nowadays.Application.Features.Queries.Company.GetCompanies
{
    public class GetCompaniesQueryResponse
    {
        public required List<ListCompany> Companies { get; set; }
    }
}
