using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Features.Commands.Employee.CreateEmployee;
using Nowadays.Application.Features.Commands.Employee.DeleteEmployee;
using Nowadays.Application.Features.Commands.Employee.UpdateEmployee;
using Nowadays.Application.Features.Queries.Employee.GetEmployeeById;
using Nowadays.Application.Features.Queries.Employee.GetEmployees;

namespace Nowadays.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
      var employees = await _mediator.Send(new GetEmployeesQueryRequest());
      return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
      var employee = await _mediator.Send(new GetEmployeeByIdQueryRequest { Id = id });
      return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommandRequest request)
    {
      var employee = await _mediator.Send(request);
      return CreatedAtAction(nameof(CreateEmployee), new { id = employee.Id }, employee);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest request)
    {
      var employee = await _mediator.Send(request);
      return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
      await _mediator.Send(new DeleteEmployeeCommandRequest { Id = id });
      return NoContent();
    }
  }
}
