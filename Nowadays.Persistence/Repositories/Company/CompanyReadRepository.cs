using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class CompanyReadRepository(NowadaysDbContext context) : ReadRepository<Company>(context), ICompanyReadRepository
  {
  }
}
