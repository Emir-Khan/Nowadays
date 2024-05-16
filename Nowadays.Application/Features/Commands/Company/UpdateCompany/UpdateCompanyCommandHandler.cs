using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Company.UpdateCompany
{
  public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
  {
    readonly ICompanyService _companyService;

    public UpdateCompanyCommandHandler(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
      var company = await _companyService.GetCompanyByIdAsync(request.Id);
      request.Name ??= company.Name;
      request.Description ??= company.Description;
      request.Address ??= company.Address;

      var updatedCompany = await _companyService.UpdateCompanyAsync(new Domain.Entities.Company
      {
        Id = request.Id,
        Name = request.Name,
        Description = request.Description,
        Address = request.Address
      });

      return new UpdateCompanyCommandResponse()
      {
        Id = updatedCompany.Id,
        Name = updatedCompany.Name,
        Description = updatedCompany.Description,
        Address = updatedCompany.Address
      };
    }
  }
}
