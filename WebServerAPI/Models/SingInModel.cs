using System.ComponentModel.DataAnnotations;

namespace WebServerAPI.Models
{
    public class SingInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
