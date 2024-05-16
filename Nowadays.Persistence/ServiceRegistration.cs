using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.Persistence.Contexts;

namespace Nowadays.Persistence
{
  public static class ServiceRegistration
  {
    public static void AddPersistenceServices(this IServiceCollection services)
    {
      services.AddDbContext<NowadaysDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

      //services.AddScoped<IPostReadRepository, PostReadRepository>();
      //services.AddScoped<IPostWriteRepository, PostWriteRepository>();
    }
  }
}
