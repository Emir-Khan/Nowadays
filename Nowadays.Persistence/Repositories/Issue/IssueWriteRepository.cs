using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence.Repositories
{
  public class IssueWriteRepository(NowadaysDbContext context) : WriteRepository<Issue>(context), IIssueWriteRepository
  {
  }
}
