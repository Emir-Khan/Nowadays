using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Commands.Company.DeleteCompany
{
  public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, DeleteCompanyCommandResponse>
  {
    readonly ICompanyService _companyService;

    public DeleteCompanyCommandHandler(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
    {
      await _companyService.DeleteCompanyAsync(request.Id);
      return new DeleteCompanyCommandResponse();
    }
  }
}
