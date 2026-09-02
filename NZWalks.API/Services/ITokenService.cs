namespace NZWalks.API.Services;

public interface ITokenService
{
    string CreateJwtToken(string userId, string email, List<string> roles);
}
