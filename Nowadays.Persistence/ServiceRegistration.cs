using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Application.Repositories;
using Nowadays.Persistence.Contexts;
using Nowadays.Persistence.Repositories;
using Nowadays.Persistence.Services;

namespace Nowadays.Persistence
{
  public static class ServiceRegistration
  {
    public static void AddPersistenceServices(this IServiceCollection services)
    {
      services.AddDbContext<NowadaysDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

      services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
      services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
      services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
      services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
      services.AddScoped<IIssueReadRepository, IssueReadRepository>();
      services.AddScoped<IIssueWriteRepository, IssueWriteRepository>();
      services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
      services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();

      services.AddScoped<ICompanyService, CompanyService>();
      services.AddScoped<IProjectService, ProjectService>();
    }
  }
}
