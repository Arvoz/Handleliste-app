using GroceriesApp.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class UserService : Repository<AppUser>, IUserService
    {
        private readonly ICryptoService _crypto;

        public UserService(GroceriesAppDb db, ICryptoService crypto) : base(db)
        {
            _crypto = crypto;
        }

        public async Task<AppUser?> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || !_crypto.VerifyPassword(password, user.Password, user.Salt)) 
                return null;

            return user;
        }

        public override async Task AddAsync(AppUser user)
        {
            user.Password = _crypto.HashPassword(user.Password, out string salt);
            user.Salt = salt;
            await base.AddAsync(user);
        }

        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user is null) return null;

            return user;
        }

        public async Task<bool> CreateNewUser(AuthDto dto)
        {
            var exist = await _db.Users.AnyAsync(u => u.Username == dto.Username);
            if (exist) return false;

            var user = CreateUserFromDto(dto);
            await AddAsync(user);
            return true;
        }

        private AppUser CreateUserFromDto(AuthDto dto)
        {
            var user = new AppUser
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = UserRole.User,
                Created = DateTime.UtcNow
            };

            return user;
        }

        
    }
}
