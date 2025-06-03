using Authentication.APIModels;

namespace Authentication.APIServices.Interfaces;

public interface ITokenService
{
  Task<string> CreateToken(User user, List<string> roles, string key, string issuer, string audience);
}