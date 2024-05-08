using System;
using System.Security.Cryptography;
using System.Text;

namespace MyUtil;

public class EncryptManager
{
    public static string GenerateSalt(int length)
    {
        byte[] salt = new byte[length];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }
    
    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
        Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(combinedBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }
    
    public static bool VerifyPassword(string enteredPassword, string storedPassword, string salt)
    {
        string hashedEnteredPassword = HashPassword(enteredPassword, salt);
        return hashedEnteredPassword == storedPassword;
    }
}
