using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs;

namespace Nowadays.Application.Features.Queries.Company.GetCompanies
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQueryRequest, GetCompaniesQueryResponse>
    {
        readonly ICompanyService _companyService;

        public GetCompaniesQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetCompaniesQueryResponse> Handle(GetCompaniesQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = await _companyService.GetCompaniesAsync();
            return new GetCompaniesQueryResponse()
            {
                Companies = companies.Select(c => new ListCompany
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Address = c.Address
                }).ToList()
            };
        }
    }
}
