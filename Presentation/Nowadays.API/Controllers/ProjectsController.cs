using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Features.Commands.Project.AssignEmployee;
using Nowadays.Application.Features.Commands.Project.CreateProject;
using Nowadays.Application.Features.Commands.Project.DeleteProject;
using Nowadays.Application.Features.Commands.Project.UpdateProject;
using Nowadays.Application.Features.Queries.Project.GetProjectById;
using Nowadays.Application.Features.Queries.Project.GetProjects;

namespace Nowadays.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController : ControllerBase
  {
    readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById([FromRoute] Guid id)
    {
      var response = await _mediator.Send(new GetProjectByIdQueryRequest { Id = id });
      return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
      var response = await _mediator.Send(new GetProjectsQueryRequest());
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommandRequest command)
    {
      var response = await _mediator.Send(command);
      return CreatedAtAction(nameof(CreateProject), new { id = response.Id }, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
    {
      await _mediator.Send(new DeleteProjectCommandRequest() { Id = id });
      return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommandRequest request)
    {
      var response = await _mediator.Send(request);
      return Ok(response);
    }

    [HttpPost("assign-employee")]
    public async Task<IActionResult> AssignEmployee([FromBody] AssignEmployeeToProjectCommandRequest request)
    {
      var response = await _mediator.Send(request);
      return Ok(response);
    }
  }
}
