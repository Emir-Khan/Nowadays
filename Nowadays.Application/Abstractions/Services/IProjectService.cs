using Nowadays.Domain.Entities;

namespace Nowadays.Application.Abstractions.Services
{
  public interface IProjectService
  {
    Task<Project> CreateAsync(Project projectDto);
    Task<Project> UpdateAsync(Project projectDto);
    Task<Project> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task DeleteAsync(Guid id);
  }
}
