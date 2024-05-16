using Microsoft.EntityFrameworkCore;
using Nowadays.Domain.Entities.Common;

namespace Nowadays.Application.Repositories
{
  public interface IRepository<T> where T : BaseEntity
  {
    DbSet<T> Table { get; }
  }
}
