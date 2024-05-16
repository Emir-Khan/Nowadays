using MediatR;

namespace Nowadays.Application.Features.Queries.Company.GetCompanyById
{
    public class GetCompanyByIdQueryRequest : IRequest<GetCompanyByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
