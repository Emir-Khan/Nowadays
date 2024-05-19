using Microsoft.Extensions.DependencyInjection;
using Nowadays.Application.Abstractions.Services;
using Nowadays.Infrastructure.Services;

namespace Nowadays.Infrastructure
{
  public static class ServiceRegistration
  {
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
      services.AddScoped<ITcknValidateService, TcknValidateService>();
    }
  }
}
