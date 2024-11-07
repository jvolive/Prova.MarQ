namespace Prova.MarQ.Domain.Interfaces.Helpers;

public interface IPinHelper
{
    (string hash, string salt) HashPin(string pin);
    bool VerifyPin(string storedHash, string storedSalt, string pin);
}
