using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Company.CreateCompany
{
  public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
  {
    readonly ICompanyService _companyService;

    public CreateCompanyCommandHandler(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
      var company = await _companyService.CreateCompanyAsync(new Domain.Entities.Company
      {
        Name = request.Name,
        Description = request.Description,
        Address = request.Address
      });
      return new CreateCompanyCommandResponse()
      {
        Id = company.Id,
        Name = company.Name,
        Description = company.Description,
        Address = company.Address
      };
    }
  }
}
