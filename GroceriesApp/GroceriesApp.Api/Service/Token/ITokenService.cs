using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
