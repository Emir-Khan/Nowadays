using Microsoft.Extensions.Configuration;

namespace Nowadays.Persistence
{
  static class Configuration
  {
    static public string ConnectionString
    {
      get
      {
        ConfigurationManager configurationManager = new();
        try
        {
          configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SHFT.API"));
          configurationManager.AddJsonFile("appsettings.json");
        }
        catch
        {
          configurationManager.AddJsonFile("appsettings.json");
        }


        return configurationManager.GetConnectionString("PostgreSQL");
      }
    }
  }
}
