namespace GroceriesApp.Api
{
    public interface ICryptoService
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string password, string storedHash, string salt);
    }
}
