using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(GroceriesAppDb db) : base(db)
        {
            
        }
    }
}
