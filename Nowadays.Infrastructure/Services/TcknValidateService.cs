using Nowadays.Application.Abstractions.Services;
using TcknValidateHelper;

namespace Nowadays.Infrastructure.Services
{
  public class TcknValidateService : ITcknValidateService
  {
    public async Task<bool> ValidateTcknAsync(string tckn, string name, string surname, DateTime birthDate)
    {
      try
      {
        name = name.Trim().ToUpper();
        surname = surname.Trim().ToUpper();

        //using var client = new HttpClient()
        //
        //  var response = await client.GetAsync($"https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx?WSDL&op=TCKimlikNoDogrula?TCKimlikNo={tckn}&Ad={name}&Soyad={surname}&DogumYili={birthDate.Year}");
        //  return response.IsSuccessStatusCode;
        //
        using var service = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
        var result = await service.TCKimlikNoDogrulaAsync(Convert.ToInt64(tckn), name, surname, birthDate.Year);

        return result.Body.TCKimlikNoDogrulaResult;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
