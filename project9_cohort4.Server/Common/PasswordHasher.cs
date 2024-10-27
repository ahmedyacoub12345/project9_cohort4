using System.Text;
using System.Security.Cryptography;

namespace project9_cohort4.Server.Common
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Compute the hash of the password
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convert byte array to a hex string
                var sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("x2")); // Convert byte to hex
                }
                return sb.ToString();
            }
        }
    }
}
