using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Report.GetEmployeeReports
{
  public class GetEmployeeReportsQueryHandler : IRequestHandler<GetEmployeeReportsQueryRequest, GetEmployeeReportsQueryResponse>
  {
    readonly IReportService _reportService;

    public GetEmployeeReportsQueryHandler(IReportService reportService)
    {
      _reportService = reportService;
    }

    public async Task<GetEmployeeReportsQueryResponse> Handle(GetEmployeeReportsQueryRequest request, CancellationToken cancellationToken)
    {
      var report = await _reportService.GetEmployeeReportsAsync(request.Id);
      return new GetEmployeeReportsQueryResponse() { EmployeeReports = report };
    }
  }
}
