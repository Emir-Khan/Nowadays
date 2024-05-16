using MediatR;

namespace Nowadays.Application.Features.Commands.Company.CreateCompany
{
  public class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
  }
}
