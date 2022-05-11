using System;
using System.Security.Cryptography;
using System.Text;

namespace BL.Security
{
    public static class PasswordHash
    {
        private const int roundCount = 1000;

        public static byte[] Calculate(string password)
        {
            if (password is null)
                throw new ArgumentNullException(nameof(password));
            if (password.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(password), "Password is to long.");

            var sha = new SHA512CryptoServiceProvider();
            var passwordHash = Encoding.UTF8.GetBytes(password);
            for (int i = 0; i < roundCount; i++)
                passwordHash = sha.ComputeHash(passwordHash);
            return passwordHash;
        }
    }
}
