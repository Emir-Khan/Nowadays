using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Report.GetIssueReports
{
  public class GetIssueReportsQueryHandler : IRequestHandler<GetIssueReportsQueryRequest, GetIssueReportsQueryResponse>
  {
    readonly IReportService _reportService;

    public GetIssueReportsQueryHandler(IReportService reportService)
    {
      _reportService = reportService;
    }

    public async Task<GetIssueReportsQueryResponse> Handle(GetIssueReportsQueryRequest request, CancellationToken cancellationToken)
    {
      var report = await _reportService.GetIssueReportsAsync(request.Id);
      return new GetIssueReportsQueryResponse() { IssueReports = report };
    }
  }
}
