using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}
