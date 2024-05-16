using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Company.GetCompanyById
{
  public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQueryRequest, GetCompanyByIdQueryResponse>
  {
    readonly ICompanyService _companyService;

    public GetCompanyByIdQueryHandler(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
    {
      var company = await _companyService.GetCompanyByIdAsync(request.Id);
      return new GetCompanyByIdQueryResponse()
      {
        Id = company.Id,
        Name = company.Name,
        Description = company.Description,
        Address = company.Address
      };
    }
  }
}
