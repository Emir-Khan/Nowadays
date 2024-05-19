using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Report.GetProjectReports
{
  public class GetProjectReportsQueryHandler : IRequestHandler<GetProjectReportsQueryRequest, GetProjectReportsQueryResponse>
  {
    readonly IReportService _reportService;

    public GetProjectReportsQueryHandler(IReportService reportService)
    {
      _reportService = reportService;
    }

    public async Task<GetProjectReportsQueryResponse> Handle(GetProjectReportsQueryRequest request, CancellationToken cancellationToken)
    {
      var report = await _reportService.GetProjectReportsAsync(request.Id);
      return new GetProjectReportsQueryResponse() { ProjectReports = report };
    }
  }
}
