using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IUserService : IRepository<AppUser>
    {
        Task<AppUser?> ValidateCredentialsAsync(string username, string password);
        Task<AppUser> GetUserByNameAsync(string username);
        Task<bool> CreateNewUser(AuthDto dto);
    }
}
