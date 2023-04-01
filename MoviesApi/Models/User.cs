using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool MarketingConsent { get; set; }

    }
}
