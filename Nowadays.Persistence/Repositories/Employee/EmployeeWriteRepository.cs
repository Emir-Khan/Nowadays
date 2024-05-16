using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class EmployeeWriteRepository(NowadaysDbContext context) : WriteRepository<Employee>(context), IEmployeeWriteRepository
  {
  }
}
