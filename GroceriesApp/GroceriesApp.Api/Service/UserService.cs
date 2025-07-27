using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class UserService : Repository<AppUser>, IUserService
    {
        private readonly CryptoService _crypto;

        public UserService(GroceriesAppDb db, CryptoService crypto) : base(db)
        {
            _crypto = crypto;
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return false;

            return _crypto.VerifyPassword(password, user.Password, user.Salt);
        }

        public override async Task AddAsync(AppUser user)
        {
            user.Password = _crypto.HashPassword(user.Password, out string salt);
            user.Salt = salt;
            await base.AddAsync(user);
        }

        public async Task<AppUser?> GetUserByNameAsync(string username)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }
    }
}
