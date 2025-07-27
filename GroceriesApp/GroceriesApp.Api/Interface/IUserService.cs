using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IUserService : IRepository<AppUser>
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<AppUser> GetUserByNameAsync(string username);
    }
}
