using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Models.Auth
{
    public class Registration
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
