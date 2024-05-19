using MediatR;
using Nowadays.Application.Abstractions.Services;

namespace Nowadays.Application.Features.Queries.Report.GetCompanyReports
{
  public class GetCompanyReportsQueryHandler : IRequestHandler<GetCompanyReportsQueryRequest, GetCompanyReportsQueryResponse>
  {
    readonly IReportService _reportService;

    public GetCompanyReportsQueryHandler(IReportService reportService)
    {
      _reportService = reportService;
    }

    public async Task<GetCompanyReportsQueryResponse> Handle(GetCompanyReportsQueryRequest request, CancellationToken cancellationToken)
    {
      var report = await _reportService.GetCompanyReportsAsync(request.Id);
      return new GetCompanyReportsQueryResponse() { CompanyReports = report };
    }
  }
}
