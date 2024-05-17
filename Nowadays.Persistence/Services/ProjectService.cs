using Microsoft.EntityFrameworkCore;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;

namespace Nowadays.Persistence.Services
{
  public class ProjectService : IProjectService
  {
    readonly IProjectReadRepository _projectReadRepository;
    readonly IProjectWriteRepository _projectWriteRepository;
    readonly IEmployeeReadRepository _employeeReadRepository;

    public ProjectService(IProjectReadRepository projectReadRepository, IProjectWriteRepository projectWriteRepository, IEmployeeReadRepository employeeReadRepository)
    {
      _projectReadRepository = projectReadRepository;
      _projectWriteRepository = projectWriteRepository;
      _employeeReadRepository = employeeReadRepository;
    }

    public async Task AssignEmployeeAsync(Guid projectId, Guid employeeId)
    {
      var project = await _projectReadRepository.GetByIdAsync(projectId.ToString());
      var employee = await _employeeReadRepository.GetByIdAsync(employeeId.ToString(), false);

      project.Employees = [employee];
      _projectWriteRepository.Update(project);

      await _projectWriteRepository.SaveAsync();
    }

    public async Task<Project> CreateAsync(Project project)
    {
      await _projectWriteRepository.AddAsync(project);
      await _projectWriteRepository.SaveAsync();
      return project;
    }

    public async Task DeleteAsync(Guid id)
    {
      await _projectWriteRepository.RemoveAsync(id.ToString());
      await _projectWriteRepository.SaveAsync();
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
      return await _projectReadRepository.GetAll(false).ToListAsync();
    }

    public async Task<Project> GetByIdAsync(Guid id)
    {
      return await _projectReadRepository.GetByIdAsync(id.ToString(), false);
    }

    public async Task<Project> UpdateAsync(Project project)
    {
      _projectWriteRepository.Update(project);
      await _projectWriteRepository.SaveAsync();
      return project;
    }
  }
}
