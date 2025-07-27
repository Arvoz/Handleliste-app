using GroceriesApp.Shared;

namespace GroceriesApp.Api.Interface
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
