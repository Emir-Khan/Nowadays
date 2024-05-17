using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Features.Commands.Issue.AssignEmployeeToIssue;
using Nowadays.Application.Features.Commands.Issue.CreateIssue;
using Nowadays.Application.Features.Commands.Issue.DeleteIssue;
using Nowadays.Application.Features.Commands.Issue.UpdateIssue;
using Nowadays.Application.Features.Queries.Issue.GetIssueById;
using Nowadays.Application.Features.Queries.Issue.GetIssues;

namespace Nowadays.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IssuesController : ControllerBase
  {
    readonly IMediator _mediator;

    public IssuesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetIssues()
    {
      var issues = await _mediator.Send(new GetIssuesQueryRequest());
      return Ok(issues);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIssueById([FromRoute] Guid id)
    {
      var issue = await _mediator.Send(new GetIssueByIdQueryRequest { Id = id });
      return Ok(issue);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssue([FromRoute] Guid id)
    {
      await _mediator.Send(new DeleteIssueCommandRequest { Id = id });
      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateIssue([FromBody] CreateIssueCommandRequest request)
    {
      var issue = await _mediator.Send(request);
      return CreatedAtAction(nameof(CreateIssue), new { id = issue.Id }, issue);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIssue([FromBody] UpdateIssueCommandRequest request)
    {
      var issue = await _mediator.Send(request);
      return Ok(issue);
    }

    [HttpPost("assign-employee")]
    public async Task<IActionResult> AssignEmployee([FromBody] AssignEmployeeToIssueCommandRequest request)
    {
      await _mediator.Send(request);
      return Ok();
    }
  }
}
