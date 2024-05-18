using Nowadays.Domain.Entities;

namespace Nowadays.Application.Abstractions.Services
{
  public interface ICompanyService
  {
    Task<Company> CreateCompanyAsync(Company company);
    Task<Company> UpdateCompanyAsync(Company company);
    Task DeleteCompanyAsync(Guid id);
    Task<Company> GetCompanyByIdAsync(Guid id);
    Task<IEnumerable<Company>> GetCompanyDetailsAsync(Guid? id = null);
    Task<IEnumerable<Company>> GetCompaniesAsync();
  }
}
