using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [EmailAddress]
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
}
