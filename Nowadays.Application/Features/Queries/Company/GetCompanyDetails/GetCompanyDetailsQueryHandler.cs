using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Project;
using Nowadays.Application.ViewModels.Company;

namespace Nowadays.Application.Features.Queries.Company.GetCompanyDetails
{
  public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQueryRequest, GetCompanyDetailsResponse>
  {
    private readonly ICompanyService _companyService;

    public GetCompanyDetailsQueryHandler(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    public async Task<GetCompanyDetailsResponse> Handle(GetCompanyDetailsQueryRequest request, CancellationToken cancellationToken)
    {
      var companies = await _companyService.GetCompanyDetailsAsync(request.Id);
      return new GetCompanyDetailsResponse
      {
        Companies = companies.Select(c => new VM_Get_CompanyDetails()
        {
          Id = c.Id,
          Name = c.Name,
          Description = c.Description,
          Address = c.Address,
          Projects = c.Projects.Select(p => new ListProject()
          {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            DueDate = p.DueDate,
            IsCompleted = p.IsCompleted,
            CompanyId = c.Id,
          }).ToList()
        })
      };
    }
  }
}
