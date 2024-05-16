using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class EmployeeReadRepository(NowadaysDbContext context) : ReadRepository<Employee>(context), IEmployeeReadRepository
  {
  }
}
