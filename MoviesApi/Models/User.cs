using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class User:IdentityUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string  Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        public override string? Email { get; set; }

        public bool MarketingConsent { get; set; }


    }
}
