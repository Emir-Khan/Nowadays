using Microsoft.EntityFrameworkCore;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;

namespace Nowadays.Persistence.Services
{
  public class CompanyService : ICompanyService
  {
    readonly ICompanyWriteRepository _companyWriteRepository;
    readonly ICompanyReadRepository _companyReadRepository;

    public CompanyService(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
    {
      _companyWriteRepository = companyWriteRepository;
      _companyReadRepository = companyReadRepository;
    }

    public async Task<Company> CreateCompanyAsync(Company company)
    {
      await _companyWriteRepository.AddAsync(company);
      await _companyWriteRepository.SaveAsync();
      return company;
    }

    public async Task DeleteCompanyAsync(Guid id)
    {
      await _companyWriteRepository.RemoveAsync(id.ToString());
      await _companyWriteRepository.SaveAsync();
    }

    public async Task<IEnumerable<Company>> GetCompaniesAsync()
    {
      return await _companyReadRepository.GetAll(false).ToListAsync();
    }

    public async Task<Company> GetCompanyByIdAsync(Guid id)
    {
      return await _companyReadRepository.GetByIdAsync(id.ToString(), false);
    }

    public async Task<Company> UpdateCompanyAsync(Company company)
    {
      _companyWriteRepository.Update(company);
      await _companyWriteRepository.SaveAsync();
      return company;
    }
  }
}
