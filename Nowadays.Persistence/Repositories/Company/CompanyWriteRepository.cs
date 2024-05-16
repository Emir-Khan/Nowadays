using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class CompanyWriteRepository(NowadaysDbContext context) : WriteRepository<Company>(context), ICompanyWriteRepository
  {
  }
}
