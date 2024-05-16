namespace Nowadays.Application.Features.Queries.Company.GetCompanyById
{
  public class GetCompanyByIdQueryResponse
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
  }
}
