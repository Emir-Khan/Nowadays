namespace Nowadays.Application.Abstractions.Services
{
  public interface ITcknValidateService
  {
    Task<bool> ValidateTcknAsync(string tckn, string name, string surname, DateTime birthDate);
  }
}
