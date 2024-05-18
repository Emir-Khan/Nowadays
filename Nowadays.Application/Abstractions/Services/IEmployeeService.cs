using Nowadays.Domain.Entities;

namespace Nowadays.Application.Abstractions.Services
{
  public interface IEmployeeService
  {
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetEmployeeDetailsAsync(Guid? id = null);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Guid id);
  }
}
