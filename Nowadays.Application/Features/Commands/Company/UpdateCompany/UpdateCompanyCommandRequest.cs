using MediatR;

namespace Nowadays.Application.Features.Commands.Company.UpdateCompany
{
  public class UpdateCompanyCommandRequest : IRequest<UpdateCompanyCommandResponse>
  {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
  }
}
