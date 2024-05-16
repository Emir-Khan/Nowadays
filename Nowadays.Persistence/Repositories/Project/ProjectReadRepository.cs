using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class ProjectReadRepository(NowadaysDbContext context) : ReadRepository<Project>(context), IProjectReadRepository
  {
  }
}
