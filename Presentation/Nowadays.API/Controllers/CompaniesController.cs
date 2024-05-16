using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Features.Commands.Company.CreateCompany;
using Nowadays.Application.Features.Commands.Company.DeleteCompany;
using Nowadays.Application.Features.Commands.Company.UpdateCompany;
using Nowadays.Application.Features.Queries.Company.GetCompanies;
using Nowadays.Application.Features.Queries.Company.GetCompanyById;

namespace Nowadays.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompaniesController : ControllerBase
  {
    readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyCommandRequest request)
    {
      var response = await _mediator.Send(request);
      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompanyAsync([FromRoute] Guid id)
    {
      await _mediator.Send(new DeleteCompanyCommandRequest { Id = id });
      return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetCompaniesAsync()
    {
      var response = await _mediator.Send(new GetCompaniesQueryRequest());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyByIdAsync([FromRoute] Guid id)
    {
      var response = await _mediator.Send(new GetCompanyByIdQueryRequest { Id = id });
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCompanyAsync([FromBody] UpdateCompanyCommandRequest request)
    {
      var response = await _mediator.Send(request);
      return Ok(response);
    }
  }
}
