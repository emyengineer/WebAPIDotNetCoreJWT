using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace MoviesApi.Dtos
{
    public class CreateUserDTO
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool MarketingConsent { get; set; }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPasword(string userEmail)
        {
            //salt = RandomNumberGenerator.GetBytes(keySize);
            byte[] salt = Encoding.UTF8.GetBytes("450d0b0db2bcf4adde5032eca1a7c416e560cf44");
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(userEmail),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

    }
}
