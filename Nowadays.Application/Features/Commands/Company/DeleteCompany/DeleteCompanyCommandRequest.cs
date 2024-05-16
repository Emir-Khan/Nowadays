using MediatR;

namespace Nowadays.Application.Features.Commands.Company.DeleteCompany
{
  public class DeleteCompanyCommandRequest : IRequest<DeleteCompanyCommandResponse>
  {
    public Guid Id { get; set; }
  }
}
