using System.Security.Cryptography;
using System.Text;

namespace Prova.MarQ.Infra.Helpers;
public static class PinHelper
{
    public static (string hash, string salt) HashPin(string pin)
    {
        using var hmac = new HMACSHA256();
        var salt = Convert.ToBase64String(hmac.Key);
        var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(pin)));
        return (hash, salt);
    }

    public static bool VerifyPin(string storedHash, string storedSalt, string pin)
    {
        using var hmac = new HMACSHA256(Convert.FromBase64String(storedSalt));
        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(pin)));
        return computedHash == storedHash;
    }
}
