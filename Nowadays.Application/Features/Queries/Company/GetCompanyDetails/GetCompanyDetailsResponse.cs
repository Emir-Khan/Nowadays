using Nowadays.Application.ViewModels.Company;

namespace Nowadays.Application.Features.Queries.Company.GetCompanyDetails
{
  public class GetCompanyDetailsResponse
  {
    public IEnumerable<VM_Get_CompanyDetails> Companies { get; set; }
  }
}
