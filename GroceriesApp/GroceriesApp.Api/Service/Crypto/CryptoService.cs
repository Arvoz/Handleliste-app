using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System.Security.Cryptography;
using System.Text;

namespace GroceriesApp.Api;

public class CryptoService : ICryptoService
{
    public string HashPassword(string password, out string salt)
    {
        salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

        using var sha256 = SHA256.Create();
        var combined = Encoding.UTF8.GetBytes(password + salt);
        var hash = sha256.ComputeHash(combined);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password, string storedHash, string salt)
    {
        using var sha256 = SHA256.Create();
        var combined = Encoding.UTF8.GetBytes(password + salt);
        var hash = sha256.ComputeHash(combined);
        var newHash = Convert.ToBase64String(hash);

        return newHash == storedHash;
    }
}
