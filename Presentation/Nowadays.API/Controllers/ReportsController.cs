using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Features.Queries.Report.GetCompanyReports;
using Nowadays.Application.Features.Queries.Report.GetEmployeeReports;
using Nowadays.Application.Features.Queries.Report.GetIssueReports;
using Nowadays.Application.Features.Queries.Report.GetProjectReports;

namespace Nowadays.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReportsController : ControllerBase
  {
    readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("company")]
    public async Task<IActionResult> GetCompanyReports()
    {
      var result = await _mediator.Send(new GetCompanyReportsQueryRequest());
      return Ok(result);
    }

    [HttpGet("employee")]
    public async Task<IActionResult> GetEmployeeReports()
    {
      var result = await _mediator.Send(new GetEmployeeReportsQueryRequest());
      return Ok(result);
    }

    [HttpGet("project")]
    public async Task<IActionResult> GetProjectReports()
    {
      var result = await _mediator.Send(new GetProjectReportsQueryRequest());
      return Ok(result);
    }

    [HttpGet("issue")]
    public async Task<IActionResult> GetIssueReports()
    {
      var result = await _mediator.Send(new GetIssueReportsQueryRequest());
      return Ok(result);
    }
  }
}
