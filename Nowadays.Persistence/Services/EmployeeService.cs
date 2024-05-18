using Microsoft.EntityFrameworkCore;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.Repositories;
using Nowadays.Domain.Entities;

namespace Nowadays.Persistence.Services
{
  public class EmployeeService : IEmployeeService
  {
    readonly IEmployeeReadRepository _employeeReadRepository;
    readonly IEmployeeWriteRepository _employeeWriteRepository;

    public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
    {
      _employeeReadRepository = employeeReadRepository;
      _employeeWriteRepository = employeeWriteRepository;
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
      // todo check tckn
      await _employeeWriteRepository.AddAsync(employee);
      await _employeeWriteRepository.SaveAsync();
      return employee;
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
      await _employeeWriteRepository.RemoveAsync(id.ToString());
      await _employeeWriteRepository.SaveAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
      return await _employeeReadRepository.GetByIdAsync(id.ToString(), false);
    }

    public async Task<IEnumerable<Employee>> GetEmployeeDetailsAsync(Guid? id = null)
    {
      IQueryable<Employee> query = _employeeReadRepository.GetAll(false);

      if (id.HasValue)
        query = query.Where(e => e.Id == id);

      return await query.Include(e => e.Projects).Include(e => e.Issues).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
      return await _employeeReadRepository.GetAll(false).ToListAsync();
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
      _employeeWriteRepository.Update(employee);
      await _employeeWriteRepository.SaveAsync();
      return employee;
    }
  }
}
