using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class IssueReadRepository(NowadaysDbContext context) : ReadRepository<Issue>(context), IIssueReadRepository
  {
  }
}
