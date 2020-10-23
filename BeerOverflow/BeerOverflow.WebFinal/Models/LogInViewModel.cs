using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Web.Models
{
    public class LogInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
