using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class ProjectWriteRepository(NowadaysDbContext context) : WriteRepository<Project>(context), IProjectWriteRepository
  {
  }
}
