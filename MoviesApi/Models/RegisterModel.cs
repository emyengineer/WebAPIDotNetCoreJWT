using System.Security.Cryptography;
using System.Text;

namespace MoviesApi.Models
{
    public class RegisterModel
    {
        

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string UserName { get; set; }

        [Required, StringLength(200)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        public bool MarketingConsent { get; set; }

        //public string Id { get; set; }

        // Hash Function used in .Net Frame Work 6 
        // Reference 
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
