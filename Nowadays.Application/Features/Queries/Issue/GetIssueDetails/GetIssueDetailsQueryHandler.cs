using MediatR;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.DTOs.Employee;
using Nowadays.Application.ViewModels.Issue;

namespace Nowadays.Application.Features.Queries.Issue.GetIssueDetails
{
  public class GetIssueDetailsQueryHandler : IRequestHandler<GetIssueDetailsQueryRequest, GetIssueDetailsQueryResponse>
  {
    readonly IIssueService _issueService;

    public GetIssueDetailsQueryHandler(IIssueService issueService)
    {
      _issueService = issueService;
    }

    public async Task<GetIssueDetailsQueryResponse> Handle(GetIssueDetailsQueryRequest request, CancellationToken cancellationToken)
    {
      var issue = await _issueService.GetIssueDetailsAsync(request.Id);

      return new GetIssueDetailsQueryResponse()
      {
        Issues = issue.Select(i => new VM_Get_IssueDetails()
        {
          Id = i.Id,
          Title = i.Title,
          Description = i.Description,
          DueDate = i.DueDate,
          IsCompleted = i.IsCompleted,
          ProjectId = i.ProjectId,
          ProjectName = i.Project.Title,
          Employees = i.Employees.Select(e => new ListEmployee
          {
            Id = e.Id,
            Name = e.Name,
            Surname = e.Surname,
            Email = e.Email,
            TCKN = e.TCKN
          })
        })
      };
    }
  }
}
